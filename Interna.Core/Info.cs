using System;

namespace Interna.Core
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class Info : Attribute
    {
        public UInt32 Length { get; set; }
        public Int32 Max { get; set; }
        public Int32 Min { get; set; }
        public Boolean NoLeadingSpaces { get; set; }
        public Char CompleteWith { get; set; }
        public Int32 LongitudMantisa { get; set; }
    }
}
