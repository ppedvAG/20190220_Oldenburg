using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests
{
    delegate void EinfacherDelegate();
    delegate void DelegateMitParameter(string txt);
    delegate long CalcDelegate(int a, int b);

    class HalloDelegate
    {
        public HalloDelegate()
        {
            EinfacherDelegate dings = EinfacheMethode;
            Action dingsAlsAction = EinfacheMethode;
            Action dingsAlsAction2 = delegate () { Console.WriteLine("Hallo"); };
            Action dingsAlsAction3 = () => { Console.WriteLine("Hallo"); };
            Action dingsAlsAction4 = () => Console.WriteLine("Hallo");


            DelegateMitParameter deleMP = ZeigeText;
            Action<string> deleMPAction = ZeigeText;
            Action<string> deleMPAction2 = (string x) => Console.WriteLine(x);
            DelegateMitParameter deleMPAction3 = (x) => Console.WriteLine(x);
            Action<string> deleMPAction4 = x => Console.WriteLine(x);
            Action<string> deleMPAction5 = Console.WriteLine;

            CalcDelegate calcDele = Sum;
            Func<int, int, long> calcDeleFunc = Sum;
            CalcDelegate calcDele2 = (int x, int y) =>
            {
                return x + y;
            };

            CalcDelegate calcDele3 = (x, y) => x + y;

            var texte = new List<string>();
            var allesWasMitBAnfängt = texte.Where(x => x.StartsWith("b"));
            var allesWasMitBAnfängt22 = texte.Where(Filter);

        }

        private bool Filter(string arg)
        {
            if (arg.StartsWith("b"))
                return true;
            else
                return false;
        }

        private long Sum(int a, int b)
        {
            return a + b;
        }

        private void ZeigeText(string txt)
        {
            Console.WriteLine(txt);
        }

        public void EinfacheMethode()
        {
            Console.WriteLine("Hallo");
        }
    }
}
