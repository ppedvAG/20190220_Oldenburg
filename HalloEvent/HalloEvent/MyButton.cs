using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalloEvent
{
    delegate void TripleClickEventHandler(int clicks);

    class MyButton : Button
    {
        public event TripleClickEventHandler TripleClick;

        int clickCount = 0;


        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            clickCount++;
            if (clickCount % 3 == 0)
            {
                TripleClick?.Invoke(clickCount);
            }
        }
    }
}
