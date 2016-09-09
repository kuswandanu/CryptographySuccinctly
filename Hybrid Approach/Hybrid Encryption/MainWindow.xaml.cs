﻿using System;
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

namespace Hybrid_Encryption
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
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender == btnAssignKey) rsaParams.AssignNewKey();
                else if (sender == btnEncrypt)
                {
                    var encryptBlock = HybridEncryption.EncryptData(txtMessage.Text, rsaParams);
                    txtEncryptedSessionKey.Text = Convert.ToBase64String(encryptBlock.EncryptedSessionKey);
                    txtEncryptedData.Text = Convert.ToBase64String(encryptBlock.EncryptedData);
                    txtIv.Text = Convert.ToBase64String(encryptBlock.Iv);
                }
                else if (sender == btnDecrypt)
                {
                    var encryptBlock = new EncryptedPacket
                    {
                        EncryptedData = Convert.FromBase64String(txtEncryptedData.Text),
                        EncryptedSessionKey = Convert.FromBase64String(txtEncryptedSessionKey.Text),
                        Iv = Convert.FromBase64String(txtIv.Text)
                    };
                    var decrypted = HybridEncryption.DecryptData(encryptBlock, rsaParams);
                    txtResult.Text = decrypted;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error\n" + exc);
            }
        }
    }
}
