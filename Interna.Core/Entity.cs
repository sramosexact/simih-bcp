using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using System.Xml.Serialization;



namespace Interna.Core
{
    [Serializable]
    [DataContract]
    public class Entity : IReflected
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        //byte[] llave;

        public Entity()
        {
            SeleccionGrafica = false;
            //llave = Encoding.ASCII.GetBytes(File.ReadAllText(ConfigurationManager.AppSettings["rutaLlave"].ToString()));
        }


        public void Release(object obj)
        {
            // Errors are ignored per Microsoft's suggestion for this type of function:
            // http://support.microsoft.com/default.aspx/kb/317109
            try
            {
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(obj);
            }
            catch
            {
            }
        }

        public void Kill(int hwnd)
        {
            uint excelPID = 0;
            IntPtr handle = (IntPtr)hwnd;
            GetWindowThreadProcessId(handle, out excelPID);

            Process process = null;
            try
            {
                process = Process.GetProcessById((int)excelPID);

                //
                // If we found a matching Excel proceess with no main window
                // associated main window, kill it.
                //
                if (process != null)
                {
                    if (process.ProcessName.ToUpper() == "EXCEL" && !process.HasExited)
                        process.Kill();
                }
            }
            catch { }
        }

        public String HtmlEncode(String x)
        {
            return System.Web.HttpUtility.HtmlEncode(x);
        }
        //[IgnoreDataMember]
        public Boolean SeleccionGrafica { get; set; }

        public object GetPropertyValue(string propertyName, Object E)
        {
            try
            {
                PropertyInfo[] pInfo = E.GetType().GetProperties(
                    BindingFlags.Instance |
                    BindingFlags.Public |
                    BindingFlags.GetProperty);
                foreach (PropertyInfo property in pInfo)
                    if (property.Name.Equals(propertyName, StringComparison.CurrentCultureIgnoreCase))
                        return property.GetValue(E, null);
                return null;
            }
            catch (Exception) { }
            return null;
        }

        public bool SetPropertyValue(string propertyName, object value, Object E)
        {
            try
            {
                if (value == null) return false;
                if (E == null) return false;
                PropertyInfo[] pInfo = E.GetType().GetProperties(
                    BindingFlags.Instance |
                    BindingFlags.Public |
                    BindingFlags.SetProperty);

                foreach (PropertyInfo property in pInfo)
                    if (property.Name.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase))
                    {

                        if (property.PropertyType.FullName.Contains(value.GetType().FullName) || value.GetType().FullName.Contains(property.PropertyType.FullName))
                            if (property.CanWrite)
                                property.SetValue(E, value, null);

                        if (property.PropertyType.FullName.ToUpper().Contains("INT"))
                        {
                            String valor1 = value.ToString();
                            int valor2 = 0;
                            Boolean resultado = false;
                            resultado = int.TryParse(valor1, out valor2);
                        }

                        return true;
                    }

                return false;
            }
            catch (Exception) { }

            return false;
        }

        public Object CloneToObject(Object E)
        {
            PropertyInfo[] pInfo = this.GetType().GetProperties(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.SetProperty);
            foreach (PropertyInfo property in pInfo)
                SetPropertyValue(property.Name, this.GetPropertyValue(property.Name), E);

            return E;
        }

        public void CopyToObject(Object E)
        {
            PropertyInfo[] pInfo = E.GetType().GetProperties(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.SetProperty);
            foreach (PropertyInfo property in pInfo)
            {
                SetPropertyValue(property.Name, GetPropertyValue(property.Name), E);
            }
        }

        public void CopyToObject(Object From, Object To)
        {
            PropertyInfo[] pInfo = From.GetType().GetProperties(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.SetProperty);
            foreach (PropertyInfo property in pInfo)
            {
                try
                {
                    SetPropertyValue(property.Name, GetPropertyValue(property.Name, From), To);
                }
                catch (Exception) { }
            }
        }

        public void CopyToMe(Object E)
        {
            try
            {
                PropertyInfo[] pInfo = this.GetType().GetProperties(
                    BindingFlags.Instance |
                    BindingFlags.Public |
                    BindingFlags.SetProperty);
                foreach (PropertyInfo property in pInfo)
                    this.SetPropertyValue(property.Name, GetPropertyValue(property.Name, E));
            }
            catch (Exception) { }
        }
        public void CopyToMe(Entity E)
        {
            PropertyInfo[] pInfo = this.GetType().GetProperties(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.SetProperty);
            foreach (PropertyInfo property in pInfo)
                this.SetPropertyValue(property.Name, E.GetPropertyValue(property.Name));
        }

        public Entity DeepCopy()
        {
            PropertyInfo[] pInfo = this.GetType().GetProperties(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.SetProperty);
            Type t = this.GetType();
            Entity o = (Entity)this.ShallowCopy();
            foreach (PropertyInfo property in pInfo)
                o.SetPropertyValue(property.Name, GetPropertyValue(property.Name));

            return o;
        }

        public T Copy<T>(T oT) where T : Entity
        {
            PropertyInfo[] pInfo2 = oT.GetType().GetProperties(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.SetProperty);

            foreach (PropertyInfo p2 in pInfo2)
                this.SetPropertyValue(p2.Name, oT.GetPropertyValue(p2.Name));

            return (T)this;
        }

        public object GetPropertyValue(string propertyName)
        {
            PropertyInfo[] pInfo = this.GetType().GetProperties(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.GetProperty);
            foreach (PropertyInfo property in pInfo)
                if (property.Name.Equals(propertyName, StringComparison.CurrentCultureIgnoreCase))
                    return property.GetValue(this, null);
            return null;
        }

        public bool AddPropertyValue(string propertyName, object value, string divisor)
        {
            if (value == null) return false;
            PropertyInfo[] pInfo = this.GetType().GetProperties(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.SetProperty);

            foreach (PropertyInfo property in pInfo)
                if (property.Name.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase))
                {
                    if (property.PropertyType.FullName.Contains(value.GetType().FullName) || value.GetType().FullName.Contains(property.PropertyType.FullName))
                    {
                        if (property.PropertyType.FullName.ToUpper().Contains("STRING"))
                        {
                            object temp = GetPropertyValue(propertyName);
                            if (temp == null) temp = "";
                            if (value == null) value = "";
                            value = value.ToString();
                            if (temp.ToString().Length == 0)
                                value = String.Concat(temp, value).Trim();
                            else
                                value = String.Concat(temp, divisor, value).Trim();

                            return SetPropertyValue(propertyName, value);
                        }
                    }
                }

            return false;
        }
        //20/11/2013
        public bool SetPropertyValue(string propertyName, object value)
        {
            if (value == null) return false;
            PropertyInfo[] pInfo = this.GetType().GetProperties(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.SetProperty);

            foreach (PropertyInfo property in pInfo)
                if (property.Name.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase))
                {
                    if (property.PropertyType.FullName.Contains(value.GetType().FullName) || value.GetType().FullName.Contains(property.PropertyType.FullName))
                        property.SetValue(this, value, null);
                    else
                    {
                        if (property.PropertyType.FullName.ToUpper().Contains("INT"))
                        {
                            String valor1 = value.ToString();
                            int valor2;
                            Boolean resultado = false;
                            resultado = int.TryParse(valor1, out valor2);

                            if (resultado)
                                property.SetValue(this, valor2, null);
                        }

                        if (property.PropertyType.FullName.ToUpper().Contains("DOUBLE"))
                        {
                            String valor1 = value.ToString();
                            double valor2 = 0;
                            Boolean resultado = false;
                            resultado = double.TryParse(valor1, out valor2);

                            if (resultado)
                                property.SetValue(this, valor2, null);
                        }

                        if (property.PropertyType.FullName.ToUpper().Contains("FLOAT"))
                        {
                            String valor1 = value.ToString();
                            float valor2 = 0;
                            Boolean resultado = false;
                            resultado = float.TryParse(valor1, out valor2);

                            if (resultado)
                                property.SetValue(this, valor2, null);
                        }

                        if (property.PropertyType.FullName.ToUpper().Contains("DATETIME"))
                        {
                            String valor1 = value.ToString();
                            DateTime valor2;
                            Boolean resultado = false;
                            resultado = DateTime.TryParse(valor1, out valor2);

                            if (resultado)
                                property.SetValue(this, valor2, null);
                        }
                    }

                    return true;
                }

            return false;
        }

        public void Format()
        {
            PropertyInfo[] pInfo = this.GetType().GetProperties(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.SetProperty);

            foreach (PropertyInfo p in pInfo)
            {
                try
                {
                    char[] spaces = { ' ' };
                    object[] mAttributes = p.GetCustomAttributes(typeof(Info), false);

                    if (mAttributes.Length > 0)
                    {
                        Info oInfo = (Info)mAttributes[0];
                        Object value = p.GetValue(this, null);

                        switch (p.PropertyType.FullName)
                        {

                            case "System.String":
                                String cadena;
                                if (value == null) value = String.Empty;
                                cadena = value.ToString();

                                if (oInfo.NoLeadingSpaces)
                                {
                                    cadena = cadena.Trim();
                                }

                                if (oInfo.Length > 0)
                                {
                                    if (cadena.Length > (int)oInfo.Length)
                                        cadena = cadena.Substring(0, (int)oInfo.Length);
                                }

                                if (oInfo.CompleteWith >= (char)32)
                                {
                                    cadena = cadena.PadRight((int)oInfo.Length, oInfo.CompleteWith);
                                }
                                p.SetValue(this, cadena, null);
                                break;

                            case "System.Int32":
                                if (value == null) value = 0;
                                Int32 oInt32 = (Int32)value;
                                if (oInfo.Max != 0)
                                    if (oInt32 > oInfo.Max) oInt32 = (Int32)oInfo.Max;
                                if (oInfo.Min != 0)
                                    if (oInt32 < oInfo.Min) oInt32 = (Int32)oInfo.Min;
                                p.SetValue(this, oInt32, null);
                                break;

                            case "System.Int64":
                                if (value == null) value = 0;
                                Int64 oInt64 = (Int64)value;
                                if (oInfo.Max != 0)
                                    if (oInt64 > oInfo.Max) oInt64 = (Int64)oInfo.Max;
                                if (oInfo.Min != 0)
                                    if (oInt64 < oInfo.Min) oInt64 = (Int64)oInfo.Min;
                                p.SetValue(this, oInt64, null);
                                break;


                            case "System.Decimal":
                                {
                                    if (value == null) value = 0;
                                    Decimal oDecimal = (Decimal)value;

                                    if (oInfo.LongitudMantisa != 0)
                                        oDecimal = Decimal.Parse(oDecimal.ToString("n" + oInfo.LongitudMantisa.ToString()));

                                    if (oInfo.Max != 0)
                                        if (oDecimal > oInfo.Max) oDecimal = (Decimal)oInfo.Max;
                                    if (oInfo.Min != 0)
                                        if (oDecimal < oInfo.Min) oDecimal = (Decimal)oInfo.Min;
                                    p.SetValue(this, oDecimal, null);
                                }
                                break;

                            case "System.Double":
                                {
                                    if (value == null) value = 0;
                                    Double oDecimal = (Double)value;

                                    if (oInfo.LongitudMantisa != 0)
                                        oDecimal = Double.Parse(oDecimal.ToString("n" + oInfo.LongitudMantisa.ToString()));

                                    if (oInfo.Max != 0)
                                        if (oDecimal > oInfo.Max) oDecimal = (Double)oInfo.Max;
                                    if (oInfo.Min != 0)
                                        if (oDecimal < oInfo.Min) oDecimal = (Double)oInfo.Min;
                                    p.SetValue(this, oDecimal, null);
                                }
                                break;


                            case "System.Float":
                                {
                                    if (value == null) value = 0;
                                    float oDecimal = (float)value;

                                    if (oInfo.LongitudMantisa != 0)

                                        oDecimal = float.Parse(oDecimal.ToString("n" + oInfo.LongitudMantisa.ToString()));

                                    if (oInfo.Max != 0)
                                        if (oDecimal > oInfo.Max) oDecimal = (float)oInfo.Max;
                                    if (oInfo.Min != 0)
                                        if (oDecimal < oInfo.Min) oDecimal = (float)oInfo.Min;
                                    p.SetValue(this, oDecimal, null);
                                }
                                break;

                            default:
                                break;
                        }
                    }
                }
                catch (Exception)
                {
                }
                finally
                {
                }
            }
        }

        public bool SetAttributeValue(string attributeName, object value)
        {
            foreach (PropertyInfo property in GetType().GetProperties(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                // Recorremos los atributos para la propiedad
                foreach (Column oColumn in property.GetCustomAttributes(typeof(Column), false))
                    // Seteamos el valor de la entidad a la trama
                    if (oColumn.Name.Equals(attributeName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (property.PropertyType.FullName.Equals(value.GetType().FullName, StringComparison.InvariantCultureIgnoreCase))
                            property.SetValue(this, value, null);
                        return true;
                    }
            return false;
        }

        private static String UTF8ByteArrayToString(Byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            String constructedString = encoding.GetString(characters);
            return constructedString;
        }

        private static Byte[] StringToUTF8ByteArray(String pXmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        }

        public void SerializeObject(String PathFile)
        {
            SetFile(PathFile, this.SerializeObject());
        }

        public String SerializeObject()
        {
            return this.SerializeObject(this);
        }

        public String SerializeObject(Object pObject)
        {
            try
            {
                String XmlizedString = null;
                MemoryStream memoryStream = new MemoryStream();
                Type t = pObject.GetType();
                XmlSerializer xs = new XmlSerializer(t);
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                xs.Serialize(xmlTextWriter, pObject);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
                memoryStream.Dispose();
                String res = "";
                res = XmlizedString.ToString().Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "").Trim();
                res = res.Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "").Trim();
                return res;
            }
            catch (Exception) { }
            return null;
        }

        public String SerializeObjectWindows(Object pObject)
        {
            try
            {
                String XmlizedString = null;
                MemoryStream memoryStream = new MemoryStream();
                Type t = pObject.GetType();
                XmlSerializer xs = new XmlSerializer(t);
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                xs.Serialize(xmlTextWriter, pObject);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
                memoryStream.Dispose();
                String res = "";
                res = XmlizedString.ToString().Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "").Trim();
                res = res.Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "").Trim();
                res = res.ToUpper();
                res = res.Replace("XMLNS:XSD=\"HTTP://WWW.W3.ORG/2001/XMLSCHEMA\" XMLNS:XSI=\"HTTP://WWW.W3.ORG/2001/XMLSCHEMA-INSTANCE\"", "").Trim();
                res = res.Replace('Ñ', 'N');
                res = res.Replace('º', ' ');
                // return res;  //  
                return res.Substring(1);
            }
            catch (Exception) { }
            return null;
        }

        public String SerializeGenericObjectToXml<T>(T objeto)
        {
            try
            {
                XmlSerializer xsSubmit = new XmlSerializer(typeof(T));
                var xml = "";
                using (var sww = new GenericStringWriter(Encoding.GetEncoding("ISO-8859-1")))
                {
                    xsSubmit.Serialize(sww, objeto, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));
                    xml = sww.ToString();
                }

                return xml;
            }
            catch (Exception ex) { ErrorLog error = new ErrorLog(); error.EscribirLog(ex); }
            return null;
        }

        public Object DeserializeObject(String PathFile)
        {
            return this.DeserializeObject(GetFile(PathFile), this.GetType());
        }

        public Object DeserializeObject(String pXmlizedString, Type t)
        {
            XmlSerializer xs = new XmlSerializer(t);
            using (MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(pXmlizedString)))
            {
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                return xs.Deserialize(memoryStream);
            }
        }

        public Entity ShallowCopy()
        {
            return (Entity)this.MemberwiseClone();
        }

        public static bool ExistFile(string Path)
        {
            return File.Exists(Path);
        }

        public void SetFile(string Path, string Data)
        {
            FileStream fs = File.Create(Path);
            byte[] b = System.Text.Encoding.UTF8.GetBytes(Data);
            fs.Write(b, 0, b.Length);
            fs.Close();
        }
        public string GetFile(string Path)
        {
            string data = "";
            using (StreamReader sr = new StreamReader(Path))
            {
                data = sr.ReadToEnd();
                sr.Close();
            }
            return data;
        }

        public static void DeleteFile(string Path)
        {
            if (ExistFile(Path))
                File.Delete(Path);
        }

        public string HTMLEncodeSpecialChars(string text)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            int i = 0;

            if (text != null)
                foreach (char c in text)
                {
                    i = 0;
                    if (c == '"') { sb.Append('-'); i = 1; }
                    if (c == '<') { sb.Append('-'); i = 1; }
                    if (c == '>') { sb.Append('-'); i = 1; }
                    if (c == '=') { sb.Append('-'); i = 1; }
                    if (c == '/') { sb.Append('|'); i = 1; }
                    if (i == 0) sb.Append(c);
                }
            return sb.ToString();
        }

        public void ConvertDataRowForObjeto(DataRow dr)
        {
            int index = 0;
            try
            {
                foreach (object oValue in dr.ItemArray)
                {
                    try
                    {
                        this.SetPropertyValue(dr.Table.Columns[index].Caption, oValue);
                    }
                    catch
                    {
                    }
                    finally
                    {
                        index++;
                    }
                    //this.Format();

                }
            }
            catch
            {
                return;

            }
        }

        public static List<T> deserializarJson<T>(string sJson)
        {
            try
            {
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<T>));
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(sJson));
                List<T> data = (List<T>)js.ReadObject(ms);
                ms.Close();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }

        }


        //public List<Dictionary<string, object>> Encriptar(List<Dictionary<string, object>> lista, params string[] atributos)
        //{
        //    List<Dictionary<string, object>> listaEncriptada = new List<Dictionary<string, object>>();
        //    lista.ForEach(elemento =>
        //    {
        //        Dictionary<string, object> nuevoElemento = new Dictionary<string, object>();
        //        foreach (KeyValuePair<string, object> dataEntry in elemento)
        //        {
        //            bool encuentra = false;
        //            foreach (string atributo in atributos)
        //            {
        //                if (atributo.Equals(dataEntry.Key))
        //                {
        //                    nuevoElemento[dataEntry.Key] = dataEntry.Value == null || dataEntry.Value.Equals("") ? "" : Encryption.Encryption.Encrypt(dataEntry.Value.ToString(), llave);
        //                    encuentra = true;
        //                    break;
        //                }
        //            }
        //            if (!encuentra)
        //            {
        //                nuevoElemento[dataEntry.Key] = dataEntry.Value;
        //            }
        //        }
        //        listaEncriptada.Add(nuevoElemento);
        //    });
        //    return listaEncriptada;
        //}

        //public List<Dictionary<string, object>> Desencriptar(List<Dictionary<string, object>> lista, params string[] atributos)
        //{
        //    List<Dictionary<string, object>> listaEncriptada = new List<Dictionary<string, object>>();
        //    lista.ForEach(elemento =>
        //    {
        //        Dictionary<string, object> nuevoElemento = new Dictionary<string, object>();
        //        foreach (KeyValuePair<string, object> dataEntry in elemento)
        //        {
        //            bool encuentra = false;
        //            foreach (string atributo in atributos)
        //            {
        //                if (atributo.Equals(dataEntry.Key))
        //                {
        //                    nuevoElemento[dataEntry.Key] = dataEntry.Value == null || dataEntry.Value.Equals("") ? "" : Encryption.Encryption.Decrypt(dataEntry.Value.ToString(), llave);
        //                    encuentra = true;
        //                    break;
        //                }
        //            }
        //            if (!encuentra)
        //            {
        //                nuevoElemento[dataEntry.Key] = dataEntry.Value;
        //            }
        //        }
        //        listaEncriptada.Add(nuevoElemento);
        //    });
        //    return listaEncriptada;
        //}

        //public string Encriptar(string datoDesencriptado)
        //{
        //    return Encryption.Encryption.Encrypt(datoDesencriptado, llave);
        //}

        //public string Desencriptar(string datoEncriptado)
        //{
        //    return Encryption.Encryption.Decrypt(datoEncriptado, llave);
        //}

    }
    public class GenericStringWriter : StringWriter
    {
        Encoding _encoding = Encoding.UTF8;

        public GenericStringWriter()
        {

        }

        public GenericStringWriter(Encoding encoding)
        {
            _encoding = encoding;
        }
        public override Encoding Encoding
        {
            get { return _encoding; }
        }
    }
}
