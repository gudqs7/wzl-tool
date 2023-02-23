using System;
using System.Text;

public static class HexUtils
{
    /// <summary>
    /// 字符串hex转bytes 可处理Mac
    /// </summary>
    /// <param name="str">字符串</param>
    /// <param name="placeLength">多少位为一个hex字符串</param>
    /// <param name="placeholder">如果有分隔符则传入</param>
    /// <returns></returns>
    public static byte[] ToHexBytes(this string str, int placeLength = 1)
    {
        string s = str;
        int l = s.Length / placeLength;
        byte[] hex = new byte[l];
        for (int i = 0; i < l; i++)
        {
            hex[i] = Convert.ToByte(Convert.ToInt32(s.Substring(i * placeLength, placeLength), 16));
        }
        return hex;
    }

}