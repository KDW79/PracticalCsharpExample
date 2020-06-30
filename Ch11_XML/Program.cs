using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch11_XML
{
    class Program
    {
        static void Main(string[] args)
        {
            var xdoc = XDocument.Load("novelists.xml");
            var xelements = xdoc.Root.Elements();
            foreach (var xnovelist in xelements)
            {
                XElement xname = xnovelist.Element("name");
                Console.WriteLine(xname.Value);
            }

            foreach (var xnovelist in xdoc.Root.Elements())
            {
                var xname = xnovelist.Element("name");
                var birth = (DateTime)xnovelist.Element("birth");
                Console.WriteLine("{0} {1}", xname.Value, birth.ToShortDateString());
            }

            Console.WriteLine("ex 11.4 ======================================================");

            foreach (var xnovelist in xdoc.Root.Elements())
            {
                var xname = xnovelist.Element("name");
                XAttribute xeng = xname.Attribute("eng");
                string xeng_ = (string)xname.Attribute("eng");
                Console.WriteLine("{0} {1} {2}", xname.Value, xeng?.Value, xeng_);
            }

            Console.WriteLine("ex 11.5 ======================================================");

            var xnovelists5 = xdoc.Root.Elements()
                .Where(x => ((DateTime)x.Element("birth")).Year >= 1900);
            foreach (var xnovelist5 in xnovelists5)
            {
                var xname5 = xnovelist5.Element("name");
                var birth = (DateTime)xnovelist5.Element("birth");
                Console.WriteLine("{0} {1}", xname5.Value, birth.ToShortDateString());
            }

            Console.WriteLine("ex 11.6 ======================================================");

            var xnovelists6 = xdoc.Root.Elements()
                .OrderBy(x => (string)(x.Element("name").Attribute("eng")));
            foreach (var xnovelist in xnovelists6)
            {
                var xname = xnovelist.Element("name");
                var birth = (DateTime)xnovelist.Element("birth");
                Console.WriteLine("{0} {1}", xname.Value, birth.ToShortDateString());
            }

            Console.WriteLine("ex 11.7 ======================================================");

            foreach (var xnovelist in xdoc.Root.Elements())
            {
                var xname = xnovelist.Element("name");
                var works = xnovelist.Element("masterpieces")
                    .Elements("title")
                    .Select(x => x.Value);
                Console.WriteLine("{0} - {1}", xname.Value, string.Join(", ", works));
            }

            Console.WriteLine("ex 11.8 ======================================================");

            var xtitles8 = xdoc.Root.Descendants("title");
            foreach (var xtitle in xtitles8)
            {
                Console.WriteLine(xtitle.Value);
            }

            Console.WriteLine("ex 11.9 ======================================================");

            var novelists9 = xdoc.Root.Elements()
                .Select(x => new
                {
                    Name = (string)x.Element("name"),
                    Birth = (DateTime)x.Element("birth"),
                    Death = (DateTime)x.Element("death")
                });
            foreach (var novelist in novelists9)
            {
                Console.WriteLine("{0} ({1}-{2})",
                    novelist.Name, novelist.Birth.Year, novelist.Death.Year);
            }

            Console.WriteLine("ex 11.10 =====================================================");

            var novelists10 = ReadNovelists();
            foreach (var novelist in novelists10)
            {
                Console.WriteLine("{0} ({1}-{2}) - {3}",
                    novelist.Name, novelist.Birth.Year, novelist.Death.Year, string.Join(", ", novelist.Masterpieces));
            }

            Console.WriteLine("ex 11.11 =====================================================");

            string xmlstring =
                @"<?xml version=""1.0"" encoding=""uft-8"" ?>
                <novelists>
                    <novelist>
                        <name eng=""Agatha Christie"">아가사 크리스티</name>
                        <birth>1890-09-15</birth>
                        <death>1976-01-12</death>
                        <masterpieces>
                            <title>그리고 아무도 없었다</title>
                            <title>오리엔트 특급 살인</title>
                        </masterpieces>
                    </novelist>
                </novelists>";
            var xdoc11 = XDocument.Parse(xmlstring);

            Console.WriteLine("ex 11.12 =====================================================");

            string elmstring =
                @"<novelist>
                    <name kana = ""h. Gildong"">홍 길동</name>
                    <birth>1862-10-12</birth>
                    <death>1910-06-12</death>
                    <masterpieces>
                        <title>현자의 물</title>
                        <title>마지막 새</title>
                    </masterpieces>
                </novelist>";
            XElement element12 = XElement.Parse(elmstring);

            var xdoc12 = XDocument.Load("novelists.xml");
            xdoc12.Root.Add(element12);
            xdoc12.Save("new_novelists.xml",SaveOptions.DisableFormatting);

            Console.WriteLine("ex 11.13 =====================================================");
            var novelists13 = new XElement("novelists",
                new XElement("novelist",
                new XElement("name", ">마크 트웨인", new XAttribute("eng", "Mark Twain")),
                new XElement("birth", "1835-11-30"),
                new XElement("death", "1910-03-21"),
                new XElement("masterpieces",
                new XElement("title", "톰 소여의 모험"),
                new XElement("title", "허클베리 핀의 모험"),
                new XElement("title", "왕자와 거지")
                )
                ),
                new XElement("novelist",
                new XElement("name", "어니스트 헤밍웨이", new XAttribute("eng", "Ernest Hemingway")),
                new XElement("birth", "1899-07-21"),
                new XElement("death", "1961-07-02"),
                new XElement("masterpieces",
                new XElement("title", "무기여 잘 있거라"),
                new XElement("title", "노인과 바다")
                )
                )
                );

            var xdoc13 = new XDocument(novelists13);

            Console.WriteLine("ex 11.14 =====================================================");
            var novelists14 = new List<Novelist> {
                new Novelist {
                Name = "마크 트웨인",
                EngName = "Mark Twain",
                Birth = DateTime.Parse("1835-11-30"),
                Death = DateTime.Parse("1910-03-21"),
                Masterpieces = new string[] { "톰 소여의 모험", "허클베리 핀의 모험", },
                },
                new Novelist {
                Name = "어니스트 헤밍웨이",
                EngName = "Ernest Hemingway",
                Birth = DateTime.Parse("1899-07-21"),
                Death = DateTime.Parse("1961-07-02"),
                Masterpieces = new string[] { "무기여 잘 있거라", "노인과 바다", },
                },
            };

            var elements14 = novelists14.Select(x =>
            new XElement("novelist",
                new XElement("name", x.Name, new XAttribute("eng", x.EngName)),
                new XElement("birth", x.Birth),
                new XElement("death", x.Death),
                new XElement("masterpieces", x.Masterpieces.Select(t => new XElement("title", t)))
                )
                );

            var root14 = new XElement("novelists", elements14);

            var xdoc14 = new XDocument(root14);

            Console.WriteLine("ex 11.15 =====================================================");

            var element15 = new XElement("novelist",
                new XElement("name", "찰스 디킨스", new XAttribute("eng", "Charles Dickens")),
                new XElement("birth", "1812-02-07"),
                new XElement("death", "1870-06-09"),
                new XElement("masterpieces",
                    new XElement("title", "올리버 트위스트"),
                    new XElement("title", "크리스마스 캐럴")
                    )
                    );

            var xdoc15 = XDocument.Load("novelists.xml");
            xdoc15.Root.Add(element15);

            foreach (var xnovelist in xdoc15.Root.Elements())
            {
                var xname = xnovelist.Element("name");
                var birth = (DateTime)xnovelist.Element("birth");
                Console.WriteLine("{0} {1}", xname.Value, birth.ToShortDateString());
            }

            Console.WriteLine("ex 11.16 =====================================================");

            var xdoc16 = XDocument.Load("novelists.xml");
            var elements16 = xdoc16.Root.Elements()
                .Where(x => x.Element("name").Value == "찰스 디킨스");
            elements16.Remove();

            foreach (var xnovelist in xdoc16.Root.Elements())
            {
                var xname = xnovelist.Element("name");
                var birth = (DateTime)xnovelist.Element("birth");
                Console.WriteLine("{0} {1}", xname.Value, birth.ToShortDateString());
            }

            Console.WriteLine("ex 11.17 =====================================================");

            var xdoc17 = XDocument.Load("novelists.xml");
            var element17 = xdoc17.Root.Elements()
                .Single(x => x.Element("name").Value == "마크 트웨인");
            string elmstring17 =
                @"<novelist>
                    <name eng=""Mark Twain"">마크 트웨인</name>
                    <birth>1890-09-15</birth>
                    <death>1976-01-12</death>
                    <masterpieces>
                        <title>도금시대</title>
                        <title>아서 왕 궁정의 코네티컷 양키</title>
                    </masterpieces>
                </novelist>";
            var newElement17 = XElement.Parse(elmstring17);
            element17.ReplaceWith(newElement17);

            foreach (var xnovelist in xdoc17.Root.Elements())
            {
                var xname = xnovelist.Element("name");
                var birth = (DateTime)xnovelist.Element("birth");
                var death = (DateTime)xnovelist.Element("death");
                var works = xnovelist.Element("masterpieces")
                    .Elements("title")
                    .Select(x => x.Value);
                Console.WriteLine("{0} {1} {2} {3}", 
                    xname.Value, 
                    birth.ToShortDateString(),
                    death.ToShortDateString(),
                    string.Join(",", works)
                    );
            }

            Console.WriteLine("ex 11.22 =====================================================");

            var option22 = new XElement("option");
            option22.SetElementValue("enabled", true);
            option22.SetElementValue("min", 0);
            option22.SetElementValue("max", 100);
            option22.SetElementValue("step", 10);
            var root = new XElement("settings", option22);
            root.Save("sample.xml");

            Console.WriteLine("ex 11.23 =====================================================");

            var option23 = new XElement("option");
            option23.SetAttributeValue("enabled", true);
            option23.SetAttributeValue("min", 0);
            option23.SetAttributeValue("max", 100);
            option23.SetAttributeValue("step", 10);
            var root23 = new XElement("settings", option23);
            root23.Save("sample23.xml");

            Console.WriteLine("ex 11.24 =====================================================");

            var xdoc24 = XDocument.Load("sample.xml");
            var option24 = xdoc24.Root.Element("option");
            Console.WriteLine((bool)option24.Element("enabled"));
            Console.WriteLine((int)option24.Element("min"));
            Console.WriteLine((int)option24.Element("max"));
            Console.WriteLine((int)option24.Element("step"));

            Console.WriteLine("ex 11.25 =====================================================");

            var xdoc25 = XDocument.Load("sample23.xml");
            var option25 = xdoc25.Root.Element("option");
            Console.WriteLine((bool)option25.Attribute("enabled"));
            Console.WriteLine((int)option25.Attribute("min"));
            Console.WriteLine((int)option25.Attribute("max"));
            Console.WriteLine((int)option25.Attribute("step"));

            Console.WriteLine("ex 11.26 =====================================================");

            var dict26 = new Dictionary<string, string>
            {
                ["IAEA"] = "국제 원자력 기구",
                ["IMF"] = "국제 통화 기금",
                ["ISO"] = "국제 표준화 기구",
            };
            var query26 = dict26.Select(x => new XElement("word",
                new XAttribute("abbr", x.Key),
                new XAttribute("korean", x.Value)));
            var root26 = new XElement("abbreviations", query26);
            root26.Save("abbreviations.xml");

            Console.WriteLine("ex 11.27 =====================================================");

            var xdoc27 = XDocument.Load("abbreviations.xml");
            var pairs27 = xdoc27.Root.Elements()
                .Select(x => new
                {
                    Key = x.Attribute("abbr").Value,
                    Value = x.Attribute("korean").Value
                });
            var dict27 = pairs27.ToDictionary(x => x.Key, x => x.Value);
            foreach (var d in dict27)
            {
                Console.WriteLine(d.Key + "=" + d.Value);
            }


            Console.WriteLine("ex 11.28 =====================================================");

            var ex28 = new XElement("abbreviations");
            ex28.SetElementValue("IAEA","국제 원자력 기구");
            ex28.SetElementValue("IMF", "국제통화기금");
            ex28.SetElementValue("ISO", "국제 표준화 기구");
            var root28 = new XElement("setting",ex28);
            var root28_1 = new XElement("setting1", root28);
            ex28.Save("abbreviations28.xml");
            root28_1.Save("ab.xml");

            var xdoc28 = XDocument.Load("abbreviations28.xml");
            var pairs28 = xdoc28.Root.Elements()
                .Select(x => new
                {
                    Key = x.Name.LocalName,
                    Value = x.Value
                });
            var dict28 = pairs28.ToDictionary(x => x.Key, x => x.Value);
            foreach (var d in dict28)
            {
                Console.WriteLine(d.Key + "=" + d.Value);
            }

            // GiFT XML 파싱

            //var xDoc = XDocument.Load("JX1-Device_Master.xml");
            //var xElements = xDoc.Root.Elements();

            //Console.WriteLine("Element Name: {0}", xDoc.Root.Name);
            //foreach (var xAttr in xDoc.Root.Attributes())
            //{
            //    Console.WriteLine("Attr Name: {0,12}, Value: {1,40}, Original XML: {2}", xAttr.Name, xAttr.Value, xAttr);
            //}


            //foreach (var xGIFT in xElements)
            //{
            //    string xName = xGIFT.Name.ToString();
            //    Console.WriteLine("Element Name: {0}", xName);
            //    foreach (var xAttr in xGIFT.Attributes())
            //    {
            //        Console.WriteLine("Attr Name: {0, 12}, Value: {1, 40}, Original XML: {2}",xAttr.Name, xAttr.Value, xAttr);
            //    }
            //}

        }

        public static IEnumerable<Novelist> ReadNovelists()
        {
            var xdoc = XDocument.Load("novelists.xml");
            var novelists = xdoc.Root.Elements()
                .Select(x => new Novelist
                {
                    Name = (string)x.Element("name"),
                    KanaName = (string)(x.Element("name").Attribute("kana")),
                    Birth = (DateTime)x.Element("birth"),
                    Death = (DateTime)x.Element("death"),
                    Masterpieces = x.Element("masterpieces")
                    .Elements("title")
                    .Select(title => title.Value)
                    .ToArray()
                });
            return novelists.ToArray();
        }

    }
}
