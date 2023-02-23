using Ionic.Zlib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace WzlTool
{
    internal class WzlUtil
    {

        public static void WriteWzlBy16(String imgDirPath, String destPath, String fileName)
        {
            DirectoryInfo imgDir = new DirectoryInfo(imgDirPath);
            if (imgDir.Exists)
            {
                if (!Directory.Exists(destPath))
                {
                    Directory.CreateDirectory(destPath);
                }
                String wzlPath = destPath + "\\" + fileName + ".wzl";
                String wzxPath = destPath + "\\" + fileName + ".wzx";

                BinaryWriter wzlOut = new BinaryWriter(new FileStream(wzlPath, FileMode.Create));
                BinaryWriter wzxOut = new BinaryWriter(new FileStream(wzxPath, FileMode.Create));

                FileInfo[] imgFiles = imgDir.GetFiles();

                int size = imgFiles.Length;

                // 写入标题, 44个字节
                wzxOut.Write("7777772e7368616e646167616d65732e636f6d6d10433e02000000008fc64b00b0b24402888b47007cc34b00".ToHexBytes(2));
                wzxOut.Write(MathUtil.intToBytes(size));

                // 标题和 6个 int(未知含义)
                wzlOut.Write("7777772e7368616e646167616d65732e636f6d6d000000000000000000000000000000000000000000000000".ToHexBytes(2));
                // 写入图片数量
                wzlOut.Write(MathUtil.intToBytes(size));
                // 写入5个 int(未知含义)
                wzlOut.Write("00000000000000000000000000000000".ToHexBytes(2));

                int offset = 64;
                foreach (FileInfo imgFile in imgFiles)
                {
                    Bitmap bufferedImage = new Bitmap(imgFile.FullName);

                    int width = bufferedImage.Width;
                    int height = bufferedImage.Height;
                    int imgSize = 0;

                    // 图片位深
                    wzlOut.Write(new byte[] { 5 });
                    // 图片是否压缩
                    wzlOut.Write(new byte[] { 0 });
                    wzlOut.Write(new byte[] { 0 });
                    wzlOut.Write(new byte[] { 0 });
                    // 宽度
                    wzlOut.Write(MathUtil.shortToBytes((short)width));
                    // 高度
                    wzlOut.Write(MathUtil.shortToBytes((short)height));
                    // 坐标偏移
                    wzlOut.Write(MathUtil.shortToBytes((short)0));
                    wzlOut.Write(MathUtil.shortToBytes((short)0));

                    MemoryStream imgDataStream = new MemoryStream(40960);
                    BinaryWriter imgDataOut = new BinaryWriter(imgDataStream);
                    for (int y = height - 1; y >= 0; y--)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            Color color = bufferedImage.GetPixel(x, y);
                            int red = color.R;
                            int green = color.G;
                            int blue = color.B;
                            int alpha = color.A;

                            // 32: 00000000 00000000 00000000 00000000
                            // 16: 00000000 00000000

                            short rgb16 = (short)((red & 0xf8) << 8 | (green & 0xfc) << 3 | (blue & 0xf8) >> 3);

                            imgDataOut.Write(MathUtil.shortToBytes(rgb16));
                        }
                    }

                    // 图片数据长度
                    bool needCompress = true;
                    if (needCompress)
                    {
                        byte[] compressBytes = ZlibStream.CompressBuffer(imgDataStream.ToArray());
                        imgSize = compressBytes.Length;
                        wzlOut.Write(MathUtil.intToBytes(imgSize));
                        wzlOut.Write(compressBytes);
                    }
                    else
                    {
                        wzlOut.Write(MathUtil.intToBytes(imgSize));
                        wzlOut.Write(imgDataStream.ToArray());
                    }

                    wzxOut.Write(MathUtil.intToBytes(offset));
                    offset += imgSize + 16;

                    wzlOut.Flush();
                    wzxOut.Flush();
                }

                wzlOut.Close();
                wzxOut.Close();
            }


        }

    }
}
