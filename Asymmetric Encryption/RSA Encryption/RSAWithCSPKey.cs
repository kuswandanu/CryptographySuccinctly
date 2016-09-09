using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RSA_Encryption
{
    class RSAWithCSPKey
    {
        const string CONTAINER_NAME = "MyContainer";
        public void AssignNewKey()
        {
            const int PROVIDER_RSA_FULL = 1;
            CspParameters cspParams = new CspParameters(PROVIDER_RSA_FULL);
            cspParams.KeyContainerName = CONTAINER_NAME;
            cspParams.Flags = CspProviderFlags.UseMachineKeyStore;
            cspParams.ProviderName = "Microsoft Strong Cryptographic Provider";
            var rsa = new RSACryptoServiceProvider(cspParams);
            rsa.PersistKeyInCsp = true;
        }
        public void DeleteKeyInCSP()
        {
            var cspParams = new CspParameters();
            cspParams.KeyContainerName = CONTAINER_NAME;
            var rsa = new RSACryptoServiceProvider(cspParams);
            rsa.PersistKeyInCsp = false;
            rsa.Clear();
        }
        public byte[] EncryptData(byte[] dataToEncrypt)
        {
            byte[] cipherbytes;
            var cspParams = new CspParameters();
            cspParams.KeyContainerName = CONTAINER_NAME;
            using (var rsa = new RSACryptoServiceProvider(2048, cspParams))
            {
                cipherbytes = rsa.Encrypt(dataToEncrypt, false);
            }
            return cipherbytes;
        }
        public byte[] DecryptData(byte[] dataToDecrypt)
        {
            byte[] plain;
            var cspParams = new CspParameters();
            cspParams.KeyContainerName = CONTAINER_NAME;
            using (var rsa = new RSACryptoServiceProvider(2048, cspParams))
            {
                plain = rsa.Decrypt(dataToDecrypt, false);
            }
            return plain;
        }
    }
}