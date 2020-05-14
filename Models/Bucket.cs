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
            Value = int.Parse(split[0]);
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