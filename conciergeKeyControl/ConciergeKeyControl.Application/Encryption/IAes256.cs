public interface IAes256{
    public string Encrypt(string text, string key, out string iv);
    public string Decrypt(string cipher, string key, string iv);
}