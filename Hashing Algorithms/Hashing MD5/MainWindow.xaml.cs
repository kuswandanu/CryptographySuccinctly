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

namespace Hashing_MD5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FocusManager.SetFocusedElement(this, txtMessage);
        }

        private void btnHash_Click(object sender, RoutedEventArgs e)
        {
            txtDigest.Text = BitConverter.ToString(HashingMD5.ComputeHashMD5(Encoding.UTF8.GetBytes(txtMessage.Text))).Replace("-", "");
        }
    }
}
