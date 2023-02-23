using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WzlTool
{
    internal class MathUtil
    {
        public static byte[] shortToBytes(short value)
        {
            byte[] src = new byte[2];
            src[1] = (byte)((value >> 8) & 0xFF);
            src[0] = (byte)(value & 0xFF);
            return src;
        }

        public static byte[] intToBytes(int value)
        {
            byte[] src = new byte[4];
            src[3] = (byte)((value >> 24) & 0xFF);
            src[2] = (byte)((value >> 16) & 0xFF);
            src[1] = (byte)((value >> 8) & 0xFF);
            src[0] = (byte)(value & 0xFF);
            return src;
        }

        /**
         * byte数组中取int数值，本方法适用于(低位在前，高位在后)的顺序，和和intToBytes（）配套使用
         *
         * @param src byte数组
         * @return int数值
         */
        public static int bytesToInt(byte[] src)
        {
            return bytesToInt(src, 0);
        }

        /**
         * byte数组中取int数值，本方法适用于(低位在前，高位在后)的顺序，和和intToBytes（）配套使用
         *
         * @param src    byte数组
         * @param offset 从数组的第offset位开始
         * @return int数值
         */
        public static int bytesToInt(byte[] src, int offset)
        {
            int value;
            value = (int)((src[offset] & 0xFF)
                    | ((src[offset + 1] & 0xFF) << 8)
                    | ((src[offset + 2] & 0xFF) << 16)
                    | ((src[offset + 3] & 0xFF) << 24));
            return value;
        }


        public static short bytesToShort(byte[] src)
        {
            return bytesToShort(src, 0);
        }

        public static short bytesToShort(byte[] src, int offset)
        {
            return (short)((src[offset] & 0xFF)
                    | ((src[offset + 1] & 0xFF) << 8));
        }

    }
}
