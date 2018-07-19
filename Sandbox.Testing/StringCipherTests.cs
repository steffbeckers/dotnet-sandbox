using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sandbox.Testing
{
    [TestClass]
    public class StringCipherTests
    {
        [TestMethod]
        public void EncryptionTest()
        {
            string password = "eaNB422sfgBwWvF7hV9pgnF8";
            string encrypted = StringCipher.Encrypt(password);
            Console.WriteLine("eaNB422sfgBwWvF7hV9pgnF8 => ENCRYPT => " + encrypted);

            Assert.AreNotEqual(password, encrypted);
        }

        [TestMethod]
        public void DecryptionTest()
        {
            string encrypted = "g6Q2KQscvhPXurVHtBFrc+9oFxL4qDQlH2XgxJ2XJekecwSKgiynaLTJvuguGyM9iRhqG9+grhSOuNBnWx19CfHd4yGn99boW+M4Pl2O/YPVA8eZ3FvlOC37vjDZHfUz";
            string password = StringCipher.Decrypt(encrypted);
            Console.WriteLine("g6Q2KQscvhPXurVHtBFrc+9oFxL4qDQlH2XgxJ2XJekecwSKgiynaLTJvuguGyM9iRhqG9+grhSOuNBnWx19CfHd4yGn99boW+M4Pl2O/YPVA8eZ3FvlOC37vjDZHfUz => DECRYPT => " + password);

            Assert.AreNotEqual(encrypted, password);
        }

        [TestMethod]
        public void EncryptionDecryptionTest()
        {
            string password = "eaNB422sfgBwWvF7hV9pgnF8";
            string encrypted = StringCipher.Encrypt(password);
            string decrypted = StringCipher.Decrypt(encrypted);

            Assert.AreEqual(password, decrypted);
        }
    }
}
