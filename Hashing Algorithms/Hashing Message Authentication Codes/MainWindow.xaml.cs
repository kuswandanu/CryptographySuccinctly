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

namespace Hashing_Message_Authentication_Codes
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
            var key = txtKey.Text == "" ? HMAC.GenerateKey() : Encoding.UTF8.GetBytes(txtKey.Text);
            //if (txtKey.Text == "") txtKey.Text = BitConverter.ToString(key);

            txtMD5.Text = BitConverter.ToString(HMAC.ComputeHMACMD5(Encoding.UTF8.GetBytes(txtMessage.Text), key)).Replace("-", "");
            txtSHA1.Text = BitConverter.ToString(HMAC.ComputeHMACSHA1(Encoding.UTF8.GetBytes(txtMessage.Text), key)).Replace("-", "");
            txtSHA256.Text = BitConverter.ToString(HMAC.ComputeHMACSHA256(Encoding.UTF8.GetBytes(txtMessage.Text), key)).Replace("-", "");
            txtSHA512.Text = BitConverter.ToString(HMAC.ComputeHMACSHA512(Encoding.UTF8.GetBytes(txtMessage.Text), key)).Replace("-", "");
        }
    }
}
