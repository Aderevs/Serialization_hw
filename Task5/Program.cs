using System.IO.Compression;
using System.Text.Json;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User()
            {
                DateOfRegistration = new DateOnly(2022, 1, 16),
                Email = "user@ukr.net",
                Name = "Ben",
                Password = "11111",
                Usermane = "userneme"
            };
            var jsonString = JsonSerializer.Serialize(user);

            using(var writer  = new StreamWriter("user.json"))
            {
                writer.WriteLine(jsonString);
            }
            using(var reader = new StreamReader("user.json"))
            {
                var result = reader.ReadToEnd();
                Console.WriteLine(result);
            }

            string jsonFilePath = "user.json";
            string compressedFilePath = "user.json.gz";

            try
            {
                if (!File.Exists(jsonFilePath))
                {
                    throw new IOException("File with such path does not exist");
                }

                using (FileStream originalFileStream = File.OpenRead(jsonFilePath))
                {
                    using (FileStream compressedFileStream = File.Create(compressedFilePath))
                    {
                        using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                        {
                            originalFileStream.CopyTo(compressionStream);
                        }
                    }
                }

                Console.WriteLine("File compressed successfully.");
            }
            catch(IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
