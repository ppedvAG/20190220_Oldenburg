using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
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
            //todo katze füttern
            //hack gibt zum mittag
            Assert.Throws<ArgumentException>(() => km.Speichern("*'*#+äü+ö+ö#äö+ü§$%&/()ljwehbflhbef", new List<Katze>()));
        }

        [Test]
        public void Katzenmanager_Speichern_katzen_null_throws()
        {
            var km = new Katzenmanager();
            Assert.Inconclusive();

            Assert.Throws<ArgumentNullException>(() => km.Speichern("c:\\temp\\katze.txt", null));

        }

        [Test]
        public void Katzenmanager_SpeichernLaden_1katze()
        {
            var km = new Katzenmanager();
            var k = new Katze() { Bauchumfang = 6, Fellfarbe = "Grün", Schwanzlänge = 32 };
            var fn = Path.Combine(TestContext.CurrentContext.WorkDirectory, "katze.xml");

            km.Speichern(fn, new[] { k });
            var result = km.Laden(fn);

            Assert.IsTrue(result.Count() == 1);
            Assert.IsTrue(result.ElementAt(0).Fellfarbe == "Grün");

        }

        [Test]
        public void Katzenmanager_SpeichernLaden_1katze_AutoFix()
        {
            var km = new Katzenmanager();
            var fix = new Fixture();

            var katzen = new List<Katze>();
            for (int i = 0; i < 100; i++)
            {
                katzen.Add(fix.Create<Katze>());
            }
            var fn = Path.Combine(TestContext.CurrentContext.WorkDirectory, "katze.xml");

            km.Speichern(fn, katzen);
            var result = km.Laden(fn);

            //Assert.IsTrue(result.Count() == 1001);
            //Assert.AreEqual(result.Count(), 1001);

            result.Count().Should().BeInRange(99, 200);


            for (int i = 0; i < result.Count(); i++)
            {
                var mk = katzen[i];
                result.ElementAt(i).Should().BeEquivalentTo(mk);
            }

            //Assert.IsTrue(result.ElementAt(0).Fellfarbe == "Grün");

        }
    }
}
