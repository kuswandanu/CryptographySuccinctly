using Advanced_Encryption_Standard;
using RSA_Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hybrid_Encryption
{
    class HybridEncryption
    {
        public static string DecryptData(EncryptedPacket encryptedPacket, RSAWithRSAParameterKey rsaParams)
        {
            var aes = new AesEncryption();
            // Decrypt AES key with RSA and then decrypt data with AES.
            var decryptedSessionKey = rsaParams.DecryptData(encryptedPacket.EncryptedSessionKey);
            var decryptedData = aes.Decrypt(encryptedPacket.EncryptedData, decryptedSessionKey, encryptedPacket.Iv);
            return Encoding.UTF8.GetString(decryptedData);
        }
        public static EncryptedPacket EncryptData(string original, RSAWithRSAParameterKey rsaParams)
        {
            var aes = new AesEncryption();
            var sessionKey = RandomCryptography.Random.GenerateRandomNumber(32);
            var encryptedPacket = new EncryptedPacket
            {
                Iv = RandomCryptography.Random.GenerateRandomNumber(16)
            };
            // Encrypt data with AES and AES key with RSA.
            encryptedPacket.EncryptedData = aes.Encrypt(Encoding.UTF8.GetBytes(original), sessionKey, encryptedPacket.Iv);
            encryptedPacket.EncryptedSessionKey = rsaParams.EncryptData(sessionKey);
            return encryptedPacket;

        }
    }
}
