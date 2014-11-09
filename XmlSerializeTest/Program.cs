using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
namespace XmlSerializeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            class1 c1 = new class1 { IntValue=1,StrValue="zhoufy"};
            string xml = XmlHelper.XmlSerialize(c1,Encoding.UTF8);
            Console.WriteLine(xml);
            Console.WriteLine("-------------------------------");

            class1 c2 = XmlHelper.XmlDeserialize<class1>(xml, Encoding.UTF8);
            Console.WriteLine("IntValue:"+c2.IntValue);
            Console.WriteLine("StrValue:"+c2.StrValue);

            class2 c21 = new class2 { IntValue = 2, StrValue = "zhoufy" };
            string xml2 = XmlHelper.XmlSerialize(c21, Encoding.UTF8);
            Console.WriteLine(xml2);
            Console.WriteLine("-------------------------------");

            class2 c22 = XmlHelper.XmlDeserialize<class2>(xml2, Encoding.UTF8);
            Console.WriteLine("IntValue:" + c22.IntValue);
            Console.WriteLine("StrValue:" + c22.StrValue);
            Console.Read();
        }
    }
    public class class1
    {
        public int IntValue { get; set; }
        public string StrValue { get; set; }
    }

    [XmlType("zz")]
    public class class2
    {
        [XmlAttribute("id")]
        public int IntValue { get; set; }

        [XmlElement("name")]
        public string StrValue { get; set; } 
    }
    public class class3
    {
        public int IntValue { get; set; }
        public string StrValue { get; set; }
    }
}
