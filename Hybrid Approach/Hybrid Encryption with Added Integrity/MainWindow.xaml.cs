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

namespace Hybrid_Encryption_with_Added_Integrity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RSA_Encryption.RSAWithRSAParameterKey rsaParams = new RSA_Encryption.RSAWithRSAParameterKey();

        public MainWindow()
        {
            InitializeComponent();

            //byte[] asd = new byte[] { 0x12, 0x2f };
            //byte[] dsa = new byte[] { 0x12, 0x21 };
            //MessageBox.Show(CompareArrays.CompareUnSecure(asd, dsa).ToString());
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender == btnAssignKey) rsaParams.AssignNewKey();
                else if (sender == btnEncrypt)
                {
                    var encryptBlock = HybridEncryptionAddedIntegrity.EncryptData(txtMessage.Text, rsaParams);
                    txtEncryptedSessionKey.Text = Convert.ToBase64String(encryptBlock.EncryptedSessionKey);
                    txtEncryptedData.Text = Convert.ToBase64String(encryptBlock.EncryptedData);
                    txtIv.Text = Convert.ToBase64String(encryptBlock.Iv);
                    txtHmac.Text = Convert.ToBase64String(encryptBlock.Hmac);
                }
                else if (sender == btnDecrypt)
                {
                    var encryptBlock = new EncryptedPacket
                    {
                        EncryptedData = Convert.FromBase64String(txtEncryptedData.Text),
                        EncryptedSessionKey = Convert.FromBase64String(txtEncryptedSessionKey.Text),
                        Iv = Convert.FromBase64String(txtIv.Text),
                        Hmac = Convert.FromBase64String(txtHmac.Text)
                    };
                    var decrypted = HybridEncryptionAddedIntegrity.DecryptData(encryptBlock, rsaParams);
                    txtResult.Text = decrypted;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error\n" + exc.Message);
            }
        }
    }
}
