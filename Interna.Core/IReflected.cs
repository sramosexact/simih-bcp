using System;

namespace Interna.Core
{
    public interface IReflected
    {
        //List<object> InternalList { get; set; }
        //List<object> GetInternalList();
        //List<T> GetInternalList<T>();
        //object GetObjectList();
        //void Add();
        //void Add(Entity e);
        //int Count();
        //void ResetIndex();
        //object GetItem();
        //object GetItem(int index);
        object GetPropertyValue(string propertyName);
        bool SetPropertyValue(string propertyName, object value);
        bool SetAttributeValue(string attributeName, object value);
        string SerializeObject();
        string SerializeObject(Object pObject);
        Object DeserializeObject(String pXmlizedString);
        Object DeserializeObject(String pXmlizedString, Type t);
        Entity ShallowCopy();
        Entity DeepCopy();
        void Format();
    }
}
