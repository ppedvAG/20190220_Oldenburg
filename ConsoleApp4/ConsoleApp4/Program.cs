using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {

        private int zahl;
        private int _zahlNeu;

        public int Zahl
        {
            get { return zahl; }
            set { zahl = value; }
        }

        public int ZahlNeu
        {
            get => _zahlNeu;
            set => _zahlNeu = value;
        }

        public int ZahlAuto { get; set; }
        public Program()
        {
            using (var mc = new MyClass())
            {

            } //dispose()

        }

        static void Main(string[] args)
        {
#if DEBUG
            //throw new ExecutionEngineException();
#endif
            int z = 22;
            DateTime heute = DateTime.Now;
            Console.WriteLine("Hallo Welt " + z.ToString() + " " + heute.ToString("dddd"));
            Console.WriteLine(string.Format("Hallo Welt {0} {1:dddd}", z, heute));
            Console.WriteLine($"Hallo Welt {z} {heute:dddd}");


            KühlSchrank kühlschrank = new KühlSchrank();

            Pinguin ping = new Pinguin();

            WasGehtAusführen(kühlschrank);
            WasGehtAusführen(ping);


            Console.ReadLine();
        }
        public static void WasGehtAusführen(ICool cool)
        {
            cool.WasGeht();
        }

    }


    public class KühlSchrank : ICool,IDisposable
    {
        public int WieCool { get; set; }

        public void WasGeht()
        {
            Console.WriteLine($"Es ist {WieCool}°C");
        }

        public void Abtauen()
        { }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }


    public class Pinguin : ICool
    {
        public int WieCool { get; set; } = -5;

        public void WasGeht()
        {
            Console.WriteLine($"Es ist {WieCool}°C");

        }
    }

    public interface ICool
    {
        void WasGeht();

        int WieCool { get; set; }
    }

    class MyClass : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
