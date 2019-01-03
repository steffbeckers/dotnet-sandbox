using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sandbox.Testing
{
    [TestClass]
    public class XMLTests
    {
        [TestMethod]
        public void SerializingObjects()
        {
            List<Dossier> dossiers = new List<Dossier>();

            Dossier steff = new Dossier()
            {
                Id = 1,
                Name = "Steff",
                Address = new Address()
                {
                    Number = 25
                }
            };

            Dossier rob = new Dossier()
            {
                Id = 2,
                Name = "Rob",
                Address = new Address()
                {
                    Number = 13,
                    Extension = "A"
                }
            };

            dossiers.Add(steff);
            dossiers.Add(rob);

            var serializer = new XmlSerializer(steff.GetType());
            using (StringWriter sw = new StringWriter())
            {
                try
                {
                    serializer.Serialize(sw, steff);
                    Console.WriteLine(sw.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            Console.WriteLine();

            serializer = new XmlSerializer(rob.GetType());
            using (StringWriter sw = new StringWriter())
            {
                try
                {
                    serializer.Serialize(sw, rob);
                    Console.WriteLine(sw.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            Console.WriteLine();

            serializer = new XmlSerializer(dossiers.GetType());
            using (StringWriter sw = new StringWriter())
            {
                try
                {
                    serializer.Serialize(sw, dossiers);
                    Console.WriteLine(sw.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            Console.WriteLine();

            Export export = new Export();
            export.Dossiers = dossiers;

            serializer = new XmlSerializer(export.GetType());
            using (StringWriter sw = new StringWriter())
            {
                try
                {
                    serializer.Serialize(sw, export);
                    Console.WriteLine(sw.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
