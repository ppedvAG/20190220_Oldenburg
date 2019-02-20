using System;
using System.Collections.Generic;
using System.IO;

namespace Calculator
{
    public class Katzenmanager
    {
        public IEnumerable<Katze> Laden(string path)
        {
            throw new NotImplementedException();
        }

        public void Speichern(string path, IEnumerable<Katze> katzen)
        {
            if (path == null)
                throw new ArgumentNullException("Pfad");
            if (string.IsNullOrWhiteSpace(path) || !!!Uri.IsWellFormedUriString(path, UriKind.RelativeOrAbsolute))
                throw new ArgumentException("Pfad");
            if (katzen == null)
                throw new ArgumentNullException("katzen");

            throw new NotImplementedException();
        }
    }
}
