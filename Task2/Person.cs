using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task2
{
    [XmlRoot("Person")]
    public class Person
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlAttribute("age")]
        public int Age { get; set; }

        public Person() { }

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {Age} years old";
        }
        public void SerializeToXml(string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Person));
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, this);
                    Console.WriteLine("Serialized successfull");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Serialization failed. Error: " + ex.Message);
            }
        }

        public static Person DeserializeFromXml(string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Person));
                using (StreamReader reader = new StreamReader(filePath))
                {
                    return (Person)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Deserialization failed. Error: " + ex.Message);
                return null;
            }
        }
    }
}