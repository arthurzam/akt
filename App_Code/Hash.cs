using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class Hash
{
    /// <summary>
    /// this is the right hash result of the admin login
    /// </summary>
    public const string adminHash = "E299759A2DC02188D594358DD909444C478E2454";

    /// <summary>
    /// this is the basic crypt key for the files
    /// </summary>
    private const string crypt_key = "arthur";

    /// <summary>
    /// calculates the hash result (40 char)
    /// </summary>
    /// <param name="text">the string to be hashed</param>
    /// <returns>the hash result - 40 char string</returns>
    public static string CalculateSHA1(string text)
    {
        const int addition = 5;

        byte[] buffer = Encoding.UTF8.GetBytes(text);
        SHA1CryptoServiceProvider cryptoTransformSHA1 = new SHA1CryptoServiceProvider();
        byte[] result = cryptoTransformSHA1.ComputeHash(buffer);
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = (byte)((result[i] + addition) % byte.MaxValue);
        }
        return BitConverter.ToString(result).Replace("-", "");
    }

    /// <summary>
    /// encrypts a file
    /// </summary>
    /// <param name="path">the path to the file</param>
    /// <param name="key">the special key to encrypt</param>
    public static void EcryptFile(string path, string key = crypt_key)
    {
        FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
        BinaryReader file_reader = new BinaryReader(file);

        FileStream temp = new FileStream(Path.GetDirectoryName(path) + @"/temp", FileMode.Create, FileAccess.Write);
        BinaryWriter temp_writer = new BinaryWriter(temp);

        string HashFull = CalculateSHA1(key), HashHalf = GetHalfHash(key);
        int number = 0;
        while (file.Length != file.Position)
        {
            byte flag = file_reader.ReadByte();
            flag += (byte)HashFull[number % HashFull.Length];
            flag += (byte)HashHalf[number % HashHalf.Length];
            temp_writer.Write(flag);
            number++;
        }

        temp_writer.Close();
        temp.Close();
        file_reader.Close();
        file.Close();

        File.Copy(Path.GetDirectoryName(path) + @"/temp", path, true);
        File.Delete(Path.GetDirectoryName(path) + @"/temp");
    }

    /// <summary>
    /// decrypts a file
    /// </summary>
    /// <param name="path">the path to the file</param>
    /// <param name="key">the special key to decrypt</param>
    public static void DecryptFile(string path, string key = crypt_key)
    {
        FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
        BinaryReader file_reader = new BinaryReader(file);

        FileStream temp = new FileStream(Path.GetDirectoryName(path) + @"/temp", FileMode.Create, FileAccess.Write);
        BinaryWriter temp_writer = new BinaryWriter(temp);

        string HashFull = CalculateSHA1(key), HashHalf = GetHalfHash(key);
        int number = 0;
        while (file.Length != file.Position)
        {
            byte flag = file_reader.ReadByte();
            flag -= (byte)HashHalf[number % HashHalf.Length];
            flag -= (byte)HashFull[number % HashFull.Length];
            temp_writer.Write(flag);
            number++;
        }

        temp_writer.Close();
        temp.Close();
        file_reader.Close();
        file.Close();

        File.Copy(Path.GetDirectoryName(path) + @"/temp", path, true);
        File.Delete(Path.GetDirectoryName(path) + @"/temp");
    }

    private static string GetHalfHash(string key)
    {
        string hash = CalculateSHA1(key);
        char[] result = new char[hash.Length * 3 / 4];
        int i = 0;
        for (; i < hash.Length * 3 / 4; i++)
        {
            result[i] = hash[i];
        }
        for (; i < hash.Length; i++)
            result[i % 10] = (char)(((byte)result[i % 10] + (byte)hash[i]) % byte.MaxValue);
        return result.ToString();
    }
}