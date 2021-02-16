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

        readonly Uri uriMacchina1 = new Uri("macchina1.jpg", UriKind.Relative);
        readonly Uri uriMacchina2 = new Uri("macchina2.jpg", UriKind.Relative);
        int posMacchina1 = 690;
        int posMacchina2 = 12;
        
        public MainWindow()
        {
            Thread t1 = new Thread(new ThreadStart(muoviMacchina1));
            ImageSource imm = new BitmapImage(uriMacchina1);
            imgMacchina1.Source = imm;

            Thread t2 = new Thread(new ThreadStart(muoviMacchina1));
            ImageSource imm1 = new BitmapImage(uriMacchina2);
            imgMacchina2.Source = imm1;

            t1.Start();
        }

        public void muoviMacchina1()
        {
            Random rn = new Random();
            int x = rn.Next(0, 1);

            if (x == 1)
            {
                while (posMacchina1 >= 12)
                {
                    posMacchina1 -= 50;

                    Thread.Sleep(TimeSpan.FromMilliseconds(500));

                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        imgMacchina1.Margin = new Thickness(posMacchina1, 100, 0, 0);
                    }));
                }

                while (posMacchina2 < 691)
                {
                    posMacchina2 += 50;

                    Thread.Sleep(TimeSpan.FromMilliseconds(500));

                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        imgMacchina2.Margin = new Thickness(posMacchina2, 100, 0, 0);
                    }));
                }
              
              }
             else
             {
                while (posMacchina2 < 691)
                {
                    posMacchina2 += 50;

                    Thread.Sleep(TimeSpan.FromMilliseconds(500));

                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        imgMacchina2.Margin = new Thickness(posMacchina2, 100, 0, 0);
                    }));
                }

                    while (posMacchina1 >= 12)
                    {
                        posMacchina1 -= 50;

                        Thread.Sleep(TimeSpan.FromMilliseconds(500));

                        this.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            imgMacchina1.Margin = new Thickness(posMacchina1, 100, 0, 0);
                        }));
                    }
             }
        }

    }
}
