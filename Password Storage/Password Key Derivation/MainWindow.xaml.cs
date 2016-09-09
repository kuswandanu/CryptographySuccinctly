using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace Password_Key_Derivation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly BackgroundWorker worker = new BackgroundWorker();
        private String password = "";
        private String result = "";

        public MainWindow()
        {
            InitializeComponent();

            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            HashPassword(password, 100);
            HashPassword(password, 1000);
            HashPassword(password, 10000);
            HashPassword(password, 50000);
            HashPassword(password, 100000);
            HashPassword(password, 200000);
            HashPassword(password, 500000);
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txtResult.Text = result;
            btnHash.IsEnabled = true;
        }

        private void btnHash_Click(object sender, RoutedEventArgs e)
        {
            btnHash.IsEnabled = !true;
            password = txtPassword.Text;
            result = "";
            worker.RunWorkerAsync();
        }

        private void HashPassword(string passwordToHash, int numberOfRounds)
        {
            var sw = new Stopwatch();
            sw.Start();
            var hashedPassword = PBKDF2.HashPassword(Encoding.UTF8.GetBytes(passwordToHash), PBKDF2.GenerateSalt(), numberOfRounds);
            sw.Stop();
            result += "Hashed Password : " + Convert.ToBase64String(hashedPassword) + "\n";
            result += "Iterations <" + numberOfRounds + "> Elapsed Time : " + sw.ElapsedMilliseconds + "ms" + "\n";
        }
    }
}
