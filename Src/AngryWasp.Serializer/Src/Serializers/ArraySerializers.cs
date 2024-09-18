using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AngryWasp.Helpers;
using AngryWasp.Math;

namespace AngryWasp.Serializer.Serializers
{
    public class ByteArraySerializer : ISerializer<byte[]>
    {
        public string Serialize(byte[] value) => value.ToHex();

        public byte[] Deserialize(string value) => value.FromHex();
    }

    public class CharArraySerializer : ISerializer<char[]>
    {
        public string Serialize(char[] value) => new string(value);

        public char[] Deserialize(string value) => value.ToCharArray();
    }
    
    public class UshortArraySerializer : ISerializer<ushort[]>
    {
        public string Serialize(ushort[] value)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var v in value)
                sb.Append(v.ToByte().ToHex());

            return sb.ToString();
        }

        public ushort[] Deserialize(string value)
        {
            string[] chunks = value.Split(4).ToArray();
            ushort[] ret = new ushort[chunks.Length];

            for (int i = 0; i < chunks.Length; i++)
                ret[i] = chunks[i].FromHex().ToUShort();

            return ret;
        }
    }

    public class ShortArraySerializer : ISerializer<short[]>
    {
        public string Serialize(short[] value)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var v in value)
                sb.Append(v.ToByte().ToHex());

            return sb.ToString();
        }

        public short[] Deserialize(string value)
        {
            string[] chunks = value.Split(4).ToArray();
            short[] ret = new short[chunks.Length];

            for (int i = 0; i < chunks.Length; i++)
                ret[i] = chunks[i].FromHex().ToShort();

            return ret;
        }
    }

    public class UintArraySerializer : ISerializer<uint[]>
    {
        public string Serialize(uint[] value)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var v in value)
                sb.Append(v.ToByte().ToHex());

            return sb.ToString();
        }

        public uint[] Deserialize(string value)
        {
            string[] chunks = value.Split(8).ToArray();
            uint[] ret = new uint[chunks.Length];

            for (int i = 0; i < chunks.Length; i++)
                ret[i] = chunks[i].FromHex().ToUInt();

            return ret;
        }
    }

    public class IntArraySerializer : ISerializer<int[]>
    {
        public string Serialize(int[] value)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var v in value)
                sb.Append(v.ToByte().ToHex());

            return sb.ToString();
        }

        public int[] Deserialize(string value)
        {
            string[] chunks = value.Split(8).ToArray();
            int[] ret = new int[chunks.Length];

            for (int i = 0; i < chunks.Length; i++)
                ret[i] = chunks[i].FromHex().ToInt();

            return ret;
        }
    }

    public class UlongArraySerializer : ISerializer<ulong[]>
    {
        public string Serialize(ulong[] value)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var v in value)
                sb.Append(v.ToByte().ToHex());

            return sb.ToString();
        }

        public ulong[] Deserialize(string value)
        {
            string[] chunks = value.Split(16).ToArray();
            ulong[] ret = new ulong[chunks.Length];

            for (int i = 0; i < chunks.Length; i++)
                ret[i] = chunks[i].FromHex().ToULong();

            return ret;
        }
    }

    public class LongArraySerializer : ISerializer<long[]>
    {
        public string Serialize(long[] value)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var v in value)
                sb.Append(v.ToByte().ToHex());

            return sb.ToString();
        }

        public long[] Deserialize(string value)
        {
            string[] chunks = value.Split(16).ToArray();
            long[] ret = new long[chunks.Length];

            for (int i = 0; i < chunks.Length; i++)
                ret[i] = chunks[i].FromHex().ToLong();

            return ret;
        }
    }

    public static class StringExtensions
    {    
        public static IEnumerable<string> Split(this string str, int length)
        {
            if (String.IsNullOrEmpty(str)) throw new ArgumentException();
            if (length < 1) throw new ArgumentException();

            for (int i = 0; i < str.Length; i += length)
            {
                if (length + i > str.Length)
                    length = str.Length - i;

                yield return str.Substring(i, length);
            }
        }
    }
}