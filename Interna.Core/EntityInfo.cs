using System;

namespace Interna.Core
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
    public class EntityMapping : Attribute
    {
        public EntityMapping(string PropertyName)
        {
            this.PropertyName = PropertyName;
        }
        private string classNameField;
        public string ClassName
        {
            get { return classNameField; }
            set { classNameField = value; }
        }

        private string propertyNameField;
        public string PropertyName
        {
            get { return propertyNameField; }
            set { propertyNameField = value; }
        }
    }
}
