using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.NUnitTests
{
    [TestFixture]
    public class KatzenmanagerTests
    {
        [Test]
        public void Katzenmanager_Speichern_path_empty_throws()
        {
            var km = new Katzenmanager();

            Assert.Throws<ArgumentException>(() => km.Speichern(string.Empty, new List<Katze>()));
        }

        [Test]
        public void Katzenmanager_Speichern_path_null_throws()
        {
            var km = new Katzenmanager();

            Assert.Throws<ArgumentNullException>(() => km.Speichern(null, new List<Katze>()));
        }

        [Test]
        public void Katzenmanager_Speichern_path_invaild_throws()
        {
            var km = new Katzenmanager();

            Assert.Throws<ArgumentException>(() => km.Speichern("*'*#+äü+ö+ö#äö+ü§$%&/()ljwehbflhbef", new List<Katze>()));
        }

        [Test]
        public void Katzenmanager_Speichern_katzen_null_throws()
        {
            var km = new Katzenmanager();

            Assert.Throws<ArgumentNullException>(() => km.Speichern("C:\temp", null));
        }
    }
