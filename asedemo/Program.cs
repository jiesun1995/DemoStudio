using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace asedemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = "c822f6d7ffa8ccf9";
            using (Stream stream = new FileStream(@"C:\Users\Administrator\Desktop\PbbU3px3049067.ts", FileMode.Open))
            {
                byte[] data =new byte[stream.Length];
                stream.Read(data, 0, data.Length-1);
                var deData= AesDecrypt(data, key);
                using (Stream newStream = new FileStream(@"C:\Users\Administrator\Desktop\new.ts", FileMode.CreateNew))
                {
                    newStream.Write(deData, 0, deData.Length - 1);
                }
            }
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
        //AES加密
        public static string AesEncrypt(byte[] valueByte, string key, string iv = "")
        {
            //if (string.IsNullOrEmpty(value)) return string.Empty;
            if (key == null) throw new Exception("未将对象引用设置到对象的实例。");
            if (key.Length < 16) throw new Exception("指定的密钥长度不能少于16位。");
            if (key.Length > 32) throw new Exception("指定的密钥长度不能多于32位。");
            if (key.Length != 16 && key.Length != 24 && key.Length != 32) throw new Exception("指定的密钥长度不明确。");
            if (!string.IsNullOrEmpty(iv))
            {
                if (iv.Length < 16) throw new Exception("指定的向量长度不能少于16位。");
            }

            var _keyByte = Encoding.UTF8.GetBytes(key);
            //var valueByte = Encoding.UTF8.GetBytes(value);
            using (var aes = new RijndaelManaged())
            {
                aes.IV = !string.IsNullOrEmpty(iv) ? Encoding.UTF8.GetBytes(iv) : Encoding.UTF8.GetBytes(key.Substring(0, 16));
                aes.Key = _keyByte;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                var cryptoTransform = aes.CreateEncryptor();
                var resultArray = cryptoTransform.TransformFinalBlock(valueByte, 0, valueByte.Length);
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
        }
        //AES解密
        public static byte[] AesDecrypt(byte[] valueByte, string key, string iv = "")
        {
            //if (string.IsNullOrEmpty(value)) return string.Empty;
            if (key == null) throw new Exception("未将对象引用设置到对象的实例。");
            if (key.Length < 16) throw new Exception("指定的密钥长度不能少于16位。");
            if (key.Length > 32) throw new Exception("指定的密钥长度不能多于32位。");
            if (key.Length != 16 && key.Length != 24 && key.Length != 32) throw new Exception("指定的密钥长度不明确。");
            if (!string.IsNullOrEmpty(iv))
            {
                if (iv.Length < 16) throw new Exception("指定的向量长度不能少于16位。");
            }

            var _keyByte = Encoding.UTF8.GetBytes(key);
            //var valueByte = Convert.FromBase64String(value);
            using (var aes = new RijndaelManaged())
            {
                aes.IV = !string.IsNullOrEmpty(iv) ? Encoding.UTF8.GetBytes(iv) : Encoding.UTF8.GetBytes(key.Substring(0, 16));
                aes.Key = _keyByte;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                var cryptoTransform = aes.CreateDecryptor();
                var resultArray = cryptoTransform.TransformFinalBlock(valueByte, 0, valueByte.Length);
                return resultArray;
            }
        }
    }
}
