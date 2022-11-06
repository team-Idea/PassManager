using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using static data_access_library.PasswordManagerDbContext;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System;

namespace data_access_library.Helpers.Config
{
    internal class LoginConfig : IEntityTypeConfiguration<Login_Item>
    {
        public void Configure(EntityTypeBuilder<Login_Item> builder)
        {
            builder.Property(l => l.Name).IsRequired().HasMaxLength(100);
            builder.Property(l => l.IsFavourite).HasDefaultValue(false);
            builder.HasOne(l => l.User).WithMany(u => u.Logins).HasForeignKey(l => l.UserId);
            builder.Property(l => l.SavedLogin).IsRequired().HasMaxLength(200).HasConversion(val => Encrypt(val),
            val => Decrypt(val)); 
            builder.Property(l => l.SavedPassword).IsRequired().HasMaxLength(200).HasConversion(val => Encrypt(val),
            val => Decrypt(val));

        }
        private static string key = "E546C8DF278CD5931069B522E695D4F2";
        private string Encrypt(string dataToEncrypt)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException("EncryptionKey", "Please initialize your encryption key.");

            if (string.IsNullOrEmpty(dataToEncrypt))
                return string.Empty;

            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(dataToEncrypt);
                        }
                        array = memoryStream.ToArray();
                    }
                }
            }
            string result = Convert.ToBase64String(array);
            return result;
        }

        private string Decrypt(string dataToDecrypt)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException("EncryptionKey", "Please initialize your encryption key.");

            if (string.IsNullOrEmpty(dataToDecrypt))
                return string.Empty;
            byte[] iv = new byte[16];

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                var buffer = Convert.FromBase64String(dataToDecrypt);
                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
