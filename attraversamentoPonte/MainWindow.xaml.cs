using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace attraversamentoPonte
{
   
    public partial class MainWindow : Window
    {
        static int buffer = 5;
        private static object x = new object();
        private static Semaphore _pool;
        readonly Uri uriMacchina1 = new Uri("macchina1.jpg", UriKind.Relative);
        readonly Uri uriMacchina2 = new Uri("macchina2.jpg", UriKind.Relative);
       

        public MainWindow()
        {
            int posMacchina1 = 0;
            int posMacchina2 = 100;

            int x =  chiPassa(posMacchina1, posMacchina2);

            Thread t1 = new Thread(new ThreadStart(muoviMacchina1( posMacchina1, posMacchina2, x )));
            ImageSource imm = new BitmapImage(uriMacchina1);
            imgMacchina1.Source = imm;
            t1.Start();

        }

        public int chiPassa(int posMacchina1, int posMacchina2)
        {

            Random rn = new Random();
            int macchinaDestra = rn.Next(0, 1);
            int x;

                    if (macchinaDestra == 1)
                    {
                            return 1;  
                    }
                    else
                    {

                        return  0;
                    }
            
        }

        public int muoviMacchina1(int posMacchina1, int posMacchina2, int x)
        { 
            if(x = 1)
            {
                while (posMacchina1 < 100)
                {
                    posMacchina1 += 100;

                    Thread.Sleep(TimeSpan.FromMilliseconds(500));

                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        imgMacchina1.Margin = new Thickness(posMacchina1, 100, 0, 0);
                    }));
                }

                while (posMacchina2 < 100)
                {
                    posMacchina2 += 100;

                    Thread.Sleep(TimeSpan.FromMilliseconds(500));

                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        imgMacchina2.Margin = new Thickness(posMacchina2, 100, 0, 0);
                    }));
                }
                return 1;
            }
            else
            {
                while (posMacchina2 < 100)
                {
                    posMacchina2 += 100;

                    Thread.Sleep(TimeSpan.FromMilliseconds(500));

                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        imgMacchina2.Margin = new Thickness(posMacchina2, 100, 0, 0);
                    }));
                }

                while (posMacchina1 < 100)
                {
                    posMacchina1 += 100;

                    Thread.Sleep(TimeSpan.FromMilliseconds(500));

                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        imgMacchina1.Margin = new Thickness(posMacchina1, 100, 0, 0);
                    }));
                }
                return 0;
            }
        }

    }
}
