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
        readonly Uri uriMacchina3 = new Uri("macchina3.jpg", UriKind.Relative);

        public MainWindow()
        {
            int posMacchina1 = 0;
            int posMacchina2 = 100;
            int posMacchina3 = 200;

            Thread t1 = new Thread(new ThreadStart(muoviMacchina));
            ImageSource imm = new BitmapImage(uriMacchina1);
            imgMacchina1.Source = imm;

            Thread t2 = new Thread(new ThreadStart(muoviMacchina));
            ImageSource imm2 = new BitmapImage(uriMacchina2);
            imgMacchina1.Source = imm2;

            Thread t3 = new Thread(new ThreadStart(muoviMacchina));
            ImageSource imm3 = new BitmapImage(uriMacchina3);
            imgMacchina1.Source = imm3;




            Thread t4 = new Thread(new ThreadStart(muoviMacchina));

            _pool = new Semaphore(0, 1);

            t4.Start();
            t5.Start();

            _pool.Release(1);
        }

        static void muoviMacchina()
        {
            for (int i = 0; i < 100; i++)
            {
                lock (x) //se x=1 significa semaforo verde quindi posso eseguire le istruzioni, se x=0 semaforo rosso
                {

                    _pool.WaitOne();

                    buffer++;

                  
                    _pool.Release();
                }

            }


        }

       
    }
}
