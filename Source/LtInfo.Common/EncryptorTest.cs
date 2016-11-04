using NUnit.Framework;

namespace LtInfo.Common
{
    [TestFixture]
    public class EncryptorTest
    {
        [Test]
        public void CanWriteAndReReadEncryptorFile()
        {
            var encryptor = new Encryptor();
            encryptor.GenerateKey();
            encryptor.GenerateVector();
            var keyFileXmlString = encryptor.ToXmlKeyFileString();

            using (var tempFile = new DisposableTempFile())
            {
                FileUtility.StringToFile(keyFileXmlString, tempFile.FileInfo);

                var keyFileContents = FileUtility.FileToString(tempFile.FileInfo);
                var encryptorFromFile = Encryptor.Instance(keyFileContents);

                Assert.That(encryptorFromFile.KeyAsString, Is.EqualTo(encryptor.KeyAsString), "Can read in the Key same as it was put into the file");
                Assert.That(encryptorFromFile.VectorAsString, Is.EqualTo(encryptor.VectorAsString), "Can read in the Vector same as it was put into the file");
            }
        }
    }
}