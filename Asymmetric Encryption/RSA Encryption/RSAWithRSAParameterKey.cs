using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RSA_Encryption
{
    public class RSAWithRSAParameterKey
    {
        private RSAParameters publicKey;
        private RSAParameters privateKey;
        public void AssignNewKey()
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                publicKey = rsa.ExportParameters(false);
                privateKey = rsa.ExportParameters(true);
            }
        }
        public byte[] EncryptData(byte[] dataToEncrypt)
        {
            byte[] cipherbytes;
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(publicKey);
                cipherbytes = rsa.Encrypt(dataToEncrypt, true);
            }
            return cipherbytes;
        }
        public byte[] DecryptData(byte[] dataToEncrypt)
        {
            byte[] plain;
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(privateKey);
                plain = rsa.Decrypt(dataToEncrypt, true);
            }
            return plain;
        }
    }
}
