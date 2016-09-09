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

namespace CryptographySuccintly
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

        private void btnClick(object sender, RoutedEventArgs e)
        {
            if (sender == btnRandom)
                new RandomCryptography.MainWindow() { Owner = Application.Current.MainWindow }.Show();
            else if (sender == btnHashingMD5)
                new Hashing_MD5.MainWindow() { Owner = Application.Current.MainWindow }.Show();
            else if (sender == btnHashingSHA)
                new Hashing_SHA.MainWindow() { Owner = Application.Current.MainWindow }.Show();
            else if (sender == btnHMAC)
                new Hashing_Message_Authentication_Codes.MainWindow() { Owner = Application.Current.MainWindow }.Show();
            else if (sender == btnHashPasswordWithSalt)
                new Hash_Password_With_Salt.MainWindow() { Owner = Application.Current.MainWindow }.Show();
            else if (sender == btnPasswordKeyDerivation)
                new Password_Key_Derivation.MainWindow() { Owner = Application.Current.MainWindow }.Show();
            else if (sender == btnDES)
                new Data_Encryption_Standard.MainWindow() { Owner = Application.Current.MainWindow }.Show();
            else if (sender == btnTripleDES)
                new TripleDES.MainWindow() { Owner = Application.Current.MainWindow }.Show();
            else if (sender == btnAES)
                new Advanced_Encryption_Standard.MainWindow() { Owner = Application.Current.MainWindow }.Show();
            else if (sender == btnRSA)
                new RSA_Encryption.MainWindow() { Owner = Application.Current.MainWindow }.Show();
            else if (sender == btnHybrid)
                new Hybrid_Encryption.MainWindow() { Owner = Application.Current.MainWindow }.Show();
            else if (sender == btnHybridIntegrity)
                new Hybrid_Encryption_with_Added_Integrity.MainWindow() { Owner = Application.Current.MainWindow }.Show();
            else if (sender == btnDigitalSignature)
                new Digital_Signature.MainWindow() { Owner = Application.Current.MainWindow }.Show();
        }
    }
}
