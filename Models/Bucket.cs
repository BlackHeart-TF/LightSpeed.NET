using System;
using System.Runtime.CompilerServices;

namespace LightspeedNET
{
    internal class Bucket
    {
        public int Max { get; set; }
        public int Value { get; set; }
        public Bucket()
        {

        }
        public Bucket(string value)
        {
            var split = value.Split('/');
            int valueint;
            var passed = int.TryParse(split[0],out valueint);
            if (!passed)
            {
                var split2 = split[0].Split('.');
                valueint = int.Parse(split2[0]) + 1;
            }
            Max = int.Parse(split[1]);
        }
        public override string ToString()
        {
            return Value + "/" + Max;
        }
        public static implicit operator string(Bucket bucket)
        {
            return bucket.ToString();
        }
    }
}