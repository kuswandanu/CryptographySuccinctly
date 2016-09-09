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

namespace TripleDES
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int ENC = 0;
        const int DEC = 1;

        public byte[] key;
        public byte[] iv;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            processEncryptDecrypt(ENC);
        }

        private void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            processEncryptDecrypt(DEC);
        }

        private void processEncryptDecrypt(int EncDec)
        {
            try
            {
                var tripledes = new TripleDESEncryption();
                key = txtKey.Text.Trim() == "" ? EncDec == ENC ? RandomCryptography.Random.GenerateRandomNumber(24) : key : Encoding.UTF8.GetBytes(txtKey.Text.Trim());
                iv = txtIV.Text.Trim() == "" ? EncDec == ENC ? RandomCryptography.Random.GenerateRandomNumber(8) : iv : Encoding.UTF8.GetBytes(txtIV.Text.Trim());

                var crypted = EncDec == ENC ? tripledes.Encrypt(Encoding.UTF8.GetBytes(txtOriginal.Text), key, iv) : tripledes.Decrypt(Convert.FromBase64String(txtEncrypted.Text), key, iv);

                switch (EncDec)
                {
                    case ENC:
                        txtEncrypted.Text = Convert.ToBase64String(crypted);
                        break;
                    case DEC:
                        txtDecrypted.Text = Encoding.UTF8.GetString(crypted);
                        break;
                }

                txtHexaKey.Text = BitConverter.ToString(key);
                txtHexaIV.Text = BitConverter.ToString(iv);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error!\n" + exc);
            }
        }

        private void txtKey_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtLengthKey.Text = txtKey.Text.Length.ToString() + " / 24 Bytes";
        }

        private void txtIV_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtLengthIV.Text = txtIV.Text.Length.ToString() + " / 8 Bytes";
        }
    }
}
