using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace RandomCryptography
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<int> s = new List<int>();
        static int A = 1;
        static int B = 10;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if(s.Count < B - A)
            {
                Random random = new Random();
                int i;
                do
                {
                    i = random.Next(A, B);
                } while (s.Contains(i));
                edit.Text = i.ToString();
                s.Add(i);
                text.Text = "";
                foreach (var item in s)
                {
                    text.Text += item;
                }
            }
        }

        private void btnRandom_Click(object sender, RoutedEventArgs e)
        {
            txtRandom.Text = Convert.ToBase64String(Random.GenerateRandomNumber(24));
        }
    }
}
