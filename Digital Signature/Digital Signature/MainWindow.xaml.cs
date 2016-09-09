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

namespace Digital_Signature
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DigitalSignature digitalSignature = new DigitalSignature();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender == btnHash)
                {
                    byte[] hashedDocument;
                    using (var sha256 = SHA256.Create())
                    {
                        hashedDocument = sha256.ComputeHash(Encoding.UTF8.GetBytes(txtMessage.Text));
                    }
                    txtHashed.Text = Convert.ToBase64String(hashedDocument);
                }
                else if (sender == btnAssignKey)
                {
                    digitalSignature.AssignNewKey();
                }
                else if (sender == btnSignData)
                {
                    var signature = digitalSignature.SignData(Convert.FromBase64String(txtHashed.Text));
                    txtSignature.Text = Convert.ToBase64String(signature);
                }
                else if (sender == btnVerify)
                {
                    var verified = digitalSignature.VerifySignature(Convert.FromBase64String(txtHashed.Text), Convert.FromBase64String(txtSignature.Text));
                    txtVerified.Text = verified ? "The digital signature has been correctly verified." : "The digital signature has NOT been correctly verified.";
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
    }
}
