using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Calculator
{
    public class Katzenmanager
    {
        public IEnumerable<Katze> Laden(string path)
        {

            using (var sr= new StreamReader(path))
            {
                var serial = new XmlSerializer(typeof(List<Katze>));
                return serial.Deserialize(sr) as IEnumerable<Katze>;
            }
        }

        public void Speichern(string path, IEnumerable<Katze> katzen)
        {
            if (path == null)
                throw new ArgumentNullException("Pfad");
            if (string.IsNullOrWhiteSpace(path) )//|| !Uri.IsWellFormedUriString(path, UriKind.RelativeOrAbsolute))
                throw new ArgumentException("Pfad");
            if (katzen == null)
                throw new ArgumentNullException("katzen");

            using (var sw = new StreamWriter(path))
            {
                var serial = new XmlSerializer(typeof(List<Katze>));
                serial.Serialize(sw, katzen.ToList());
            }

        }
    }
}
