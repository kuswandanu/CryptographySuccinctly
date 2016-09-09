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

namespace Hashing_SHA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnHash_Click(object sender, RoutedEventArgs e)
        {
            txtSHA1.Text = BitConverter.ToString(HashingSHA.ComputeHashSHA1(Encoding.UTF8.GetBytes(txtMessage.Text))).Replace("-", "");
            txtSHA256.Text = BitConverter.ToString(HashingSHA.ComputeHashSHA256(Encoding.UTF8.GetBytes(txtMessage.Text))).Replace("-", "");
            txtSHA512.Text = BitConverter.ToString(HashingSHA.ComputeHashSHA512(Encoding.UTF8.GetBytes(txtMessage.Text))).Replace("-", "");
        }
    }
}
