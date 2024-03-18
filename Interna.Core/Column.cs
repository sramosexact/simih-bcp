using System;

namespace Interna.Core
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class Column : Attribute
    {
        public String Name { get; set; }

    }
}
