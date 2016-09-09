using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Hash_Password_With_Salt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private byte[] salt;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnHash_Click(object sender, RoutedEventArgs e)
        {
            salt = Hash.GenerateSalt();
            txtSalt.Text = BitConverter.ToString(salt)
                .Replace("-", "")
                ;
            txtHashed.Text = BitConverter.ToString(Hash.HashPasswordWithSalt(Encoding.UTF8.GetBytes(txtPassword.Text), salt))
                .Replace("-", "")
                ;

            //txtHashed.Text = Convert.ToBase64String(salt);
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            if (salt != null)
                MessageBox.Show(
                    (txtHashed.Text == BitConverter.ToString(Hash.HashPasswordWithSalt(Encoding.UTF8.GetBytes(txtCheck.Text), salt)).Replace("-", ""))
                    ? "Cocok!" 
                    : "Tidak Cocok!!!"
                    );
        }
    }
}
