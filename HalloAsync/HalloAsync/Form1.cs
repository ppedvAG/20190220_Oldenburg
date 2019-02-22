using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalloAsync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                progressBar1.Value = i;
                Text = $"{i}";
                Thread.Sleep(1000);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Value = i; });

                    Thread.Sleep(100);
                }
                progressBar1.Invoke((MethodInvoker)delegate { button2.Enabled = !false; });
            });


        }

        private void button3_Click(object sender, EventArgs e)
        {
            var ts = TaskScheduler.FromCurrentSynchronizationContext();
            cts = new CancellationTokenSource();
            button3.Enabled = false;
            Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    Thread.Sleep(10);
                    int z = i;
                    Task.Factory.StartNew(() => progressBar1.Value = z,
                                            cts.Token,
                                            TaskCreationOptions.None,
                                            ts);

                    if (cts.IsCancellationRequested)
                    {
                        //cleaniup
                        break;
                    }
                }
            }, cts.Token).ContinueWith(t => button3.Enabled = !false, CancellationToken.None, TaskContinuationOptions.None, ts)
                         .ContinueWith(t => MessageBox.Show("Fertig"), cts.Token, TaskContinuationOptions.None, ts);
        }

        CancellationTokenSource cts;

        private void button4_Click(object sender, EventArgs e)
        {
            cts?.Cancel();

        }

        private async void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                progressBar1.Value = i;
                await Task.Delay(100);
            }
        }


        private long AlteLangsameFunction(int zahl)
        {
            Thread.Sleep(2000);
            return zahl * 2;
        }

        private Task<long> AlteLangsameFunctionAsync(int zahl)
        {
            return Task.Run<long>(() => AlteLangsameFunction(zahl));
        }


        private async void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show((await AlteLangsameFunctionAsync(48)).ToString());
        }
    }
}
