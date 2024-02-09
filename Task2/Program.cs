namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Klarc", "Stadnichuk", 19);
            person.SerializeToXml("person.xml");
            Console.WriteLine(Person.DeserializeFromXml("person.xml"));
        }
    }
}
