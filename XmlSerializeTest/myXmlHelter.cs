using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Web;
namespace XmlSerializeTest
{
    public static class myXmlHelter
    {
        private static void XmlSerializeInternal(Stream stream,object o,Encoding encoding)
        {
            if (o == null)
                throw new ArgumentNullException("要序列化的对象为NULL!");
            if (encoding == null)
                throw new ArgumentNullException("没有指定编码类型！");
            XmlSerializer serializer = new XmlSerializer(o.GetType());

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineChars = "\r\n";
            settings.Encoding = encoding;
            settings.IndentChars = "   ";
            using(XmlWriter writer = XmlWriter.Create(stream,settings))
            {
                serializer.Serialize(writer, o);
                writer.Close();
            }
        }
        /// <summary>
        /// 将一个对象序列化为xml字符串
        /// </summary>
        /// <param name="o"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string XmlSerialize(object o,Encoding encoding)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializeInternal(stream, o, encoding);
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream,encoding) )
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
