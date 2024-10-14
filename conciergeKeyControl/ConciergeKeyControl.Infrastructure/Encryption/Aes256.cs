using System.Security.Cryptography;

public class Aes256 : IAes256
{
    public string Decrypt(string cipher, string key, string iv)
    {
       using (var aes = Aes.Create()){
        aes.Padding = PaddingMode.Zeros;
        aes.Key = Convert.FromBase64String(key);
        aes.IV = Convert.FromBase64String(iv);
        var decryptor = aes.CreateDecryptor();
        var text = "";
        byte[] ciper = Convert.FromBase64String(cipher);
        using (MemoryStream ms = new MemoryStream(ciper)){
            using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read)){
                using(StreamReader sr = new StreamReader(cs)){
                    text = sr.ReadToEnd();
                }
            }
        }
        return text;
       }
    }

    public string Encrypt(string text, string key, out string iv)
    {
         using(var aes = Aes.Create()){
            aes.Padding = PaddingMode.Zeros;
            aes.Key = Convert.FromBase64String(key);
            aes.GenerateIV();
            iv = Convert.ToBase64String(aes.IV);
            var encryptor = aes.CreateEncryptor();
            byte[] encryptedData;
            using(MemoryStream ms = new MemoryStream()){
                using(CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write)){
                    using(StreamWriter sw = new StreamWriter(cs)){
                        sw.Write(text);
                    }
                    encryptedData=ms.ToArray();
                }
            }
            return Convert.ToBase64String(encryptedData);
        }
    }
}