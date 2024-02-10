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
        }
    }
}
