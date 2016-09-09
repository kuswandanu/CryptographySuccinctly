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

namespace RSA_Encryption
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RSAWithRSAParameterKey rsaParams = new RSAWithRSAParameterKey();
        RSAWithXMLKey rsaXml = new RSAWithXMLKey();
        const string publicKeyPath = "c:\\temp\\publickey.xml";
        const string privateKeyPath = "c:\\temp\\privatekey.xml";
        RSAWithCSPKey rsaCsp = new RSAWithCSPKey();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAll(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender == btnAssignKeyParameterKey) rsaParams.AssignNewKey();
                else if (sender == btnAssignKeyXMLKey) rsaXml.AssignNewKey(publicKeyPath, privateKeyPath);
                else if (sender == btnAssignKeyCSPKey) rsaCsp.AssignNewKey();
                else if (sender == btnDeleteKeyCSPKey) rsaCsp.DeleteKeyInCSP();

                else if (sender == btnEncRSAParameterKey)
                {
                    var encryptedParams = rsaParams.EncryptData(Encoding.UTF8.GetBytes(txtMessage.Text));
                    txtEncRSAParameterKey.Text = Convert.ToBase64String(encryptedParams);
                }
                else if (sender == btnDecRSAParameterKey)
                {
                    var decryptedParams = rsaParams.DecryptData(Convert.FromBase64String(txtEncRSAParameterKey.Text));
                    txtDecRSAParameterKey.Text = Encoding.UTF8.GetString(decryptedParams);
                }

                else if (sender == btnEncRSAXMLKey)
                {
                    var encryptedXml = rsaXml.EncryptData(publicKeyPath, Encoding.UTF8.GetBytes(txtMessage.Text));
                    txtEncRSAXMLKey.Text = Convert.ToBase64String(encryptedXml);
                }
                else if (sender == btnDecRSAXMLKey)
                {
                    var decryptedXml = rsaXml.DecryptData(privateKeyPath, Convert.FromBase64String(txtEncRSAXMLKey.Text));
                    txtDecRSAXMLKey.Text = Encoding.UTF8.GetString(decryptedXml);
                }

                else if (sender == btnEncRSACSPKey)
                {
                    var encryptedCsp = rsaCsp.EncryptData(Encoding.UTF8.GetBytes(txtMessage.Text));
                    txtEncRSACSPKey.Text = Convert.ToBase64String(encryptedCsp);
                }
                else if (sender == btnDecRSACSPKey)
                {
                    var decryptedCsp = rsaCsp.DecryptData(Convert.FromBase64String(txtEncRSACSPKey.Text));
                    txtDecRSACSPKey.Text = Encoding.UTF8.GetString(decryptedCsp);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error:\n" + exc);
            }
        }
    }
}
