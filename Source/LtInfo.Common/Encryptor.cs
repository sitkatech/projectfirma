using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace LtInfo.Common
{
    public class Encryptor
    {
        private readonly TripleDESCryptoServiceProvider _des = new TripleDESCryptoServiceProvider();
        private byte[] _key;
        private string _keyCode = "";
        private byte[] _iv;
        private string _ivCode = "";
        
        public Encryptor()
        {
        }
        
        public Encryptor(string key, string vector)
        {
            _key = Convert.FromBase64String(key);
            _iv = Convert.FromBase64String(vector);
        }
        
        public Encryptor(byte[] key, byte[] vector)
        {
            _key = key;
            _iv = vector;
        }
        
        public string KeyInitializer
        {
            get
            {
                return _keyCode;
            }
        }
        
        public string VectorInitializer
        {
            get
            {
                return _ivCode;
            }
        }
        
        public static Encryptor Instance(FileInfo keyFile)
        {
            return Instance(FileUtility.FileToString(keyFile));
        }

        public static Encryptor Instance(string keyFileContents)
        {
            string keyData;
            string vectorData;
            using (var tr = new StringReader(keyFileContents))
            {
                var settings = new XmlReaderSettings();
                using (var reader = XmlReader.Create(tr, settings))
                {
                    var doc = new XmlDocument {XmlResolver = null};
                    doc.Load(reader);

                    var keyNode = doc.SelectSingleNode("/cipher-config/key");
                    if (keyNode == null)
                    {
                        throw (new ApplicationException("Missing <key> element in cipher file"));
                    }
            
                    var vectorNode = doc.SelectSingleNode("/cipher-config/vector");
                    if (vectorNode == null)
                    {
                        throw (new ApplicationException("Missing <vector> element in cipher file"));
                    }
                    keyData = keyNode.InnerXml;
                    vectorData = vectorNode.InnerXml;
                    reader.Close();
                }
                tr.Close();
            }

            return new Encryptor(keyData, vectorData);
        }
        
        public string GenerateKey()
        {
            
            _des.GenerateKey();
            _key = _des.Key;
            
            var sb = new StringBuilder();
            foreach (byte b in _key)
            {
                sb.Append(b + ",");
            }
            sb.Remove(sb.Length - 1, 1);
            _keyCode = "{" + sb + "}";

            return KeyAsString;
        }

        internal string KeyAsString
        {
            get { return Convert.ToBase64String(_key); }
        }

        public string GenerateVector()
        {
            
            _des.GenerateIV();
            _iv = _des.IV;
            
            var sb = new StringBuilder();
            foreach (byte b in _iv)
            {
                sb.Append(b + ",");
            }
            sb.Remove(sb.Length - 1, 1);
            _ivCode = "{" + sb + "}";
            
            return VectorAsString;
        }

        internal string VectorAsString
        {
            get { return Convert.ToBase64String(_iv); }
        }

        public string Encrypt(string text)
        {
            
            byte[] input = Encoding.Unicode.GetBytes(text);
            byte[] output = Transform(input, _des.CreateEncryptor(_key, _iv));
            return Convert.ToBase64String(output);
            
        }
        
        public string Decrypt(string text)
        {
            byte[] input = Convert.FromBase64String(text);
            byte[] output = Transform(input, _des.CreateDecryptor(_key, _iv));
            return Encoding.Unicode.GetString(output);
            
        }
        
        private static byte[] Transform(byte[] input, ICryptoTransform cryptoTransform)
        {
            
            var memStream = new MemoryStream();
            var cryptStream = new CryptoStream(memStream, cryptoTransform, CryptoStreamMode.Write);
            
            cryptStream.Write(input, 0, input.Length);
            cryptStream.FlushFinalBlock();

            var result = new byte[memStream.Length];
            
            memStream.Position = 0;
            memStream.Read(result, 0, result.Length);
            memStream.Close();
            cryptStream.Close();
            
            return result;
            
        }

        public string ToXmlKeyFileString()
        {
            var asXmlKeyFileString = string.Format(
@"<?xml version=""1.0"" encoding=""utf-8"" ?>
<cipher-config>
    <key>{0}</key>
    <vector>{1}</vector>
</cipher-config>", KeyAsString, VectorAsString);
            return asXmlKeyFileString;
        }
    }
}