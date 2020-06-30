using System.Xml;
using System.Runtime.Serialization;
using System.Threading;

namespace Ch12_Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1;

            var novel = new Novel
            {
                Author = "제임스 P. 호건",
                Title = "별의 계승자",
                Published = 1977,
            };

            var settings = new XmlWriterSettings
            {
                Encoding = new System.Text.UTF8Encoding(false),
                Indent = true,
                IndentChars = "  ",
            };
            
            //var serializer = new DataContractSerializer(novel.GetType());

            using (var writer = XmlWriter.Create("novel.xml", settings))
            {
            }
        }
    }
}
