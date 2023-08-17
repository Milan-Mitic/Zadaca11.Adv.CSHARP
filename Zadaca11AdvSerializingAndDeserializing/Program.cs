using Newtonsoft.Json;
namespace Zadaca11AdvSerializingAndDeserializing

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person()
            {
                Name = "Zoran",
                Surname = "Malinovic",
                Age = 20,
                Courses = new List<Course>
                 {
                     new Course() { Name = "C#",  Grade = 10},
                     new Course() { Name = "SQL", Grade = 10},
                     new Course() { Name = "C++", Grade = 10}
                 }
            };

            string jsonFilePath = "OnePerson.json";
            string json = JsonConvert.SerializeObject(person, Formatting.Indented);
            File.WriteAllText(jsonFilePath, json);
            Console.WriteLine($"Person info saved to {jsonFilePath}");

            Console.WriteLine("\n**** Reading and writing all person info **** ");

            string jsonFromFile = File.ReadAllText(jsonFilePath);

            Person deserializedPerson = JsonConvert.DeserializeObject<Person>(jsonFromFile);

            Console.WriteLine("\nDeserialized Person object: ");
            Console.WriteLine($" Name: {deserializedPerson.Name}");
            Console.WriteLine($" Surname: {deserializedPerson.Surname}");
            Console.WriteLine($" Age: {deserializedPerson.Age}");
            Console.WriteLine("Courses: ");

            foreach(Course course in deserializedPerson.Courses)
                Console.WriteLine($"  {course.Name}: {course.Grade}");
        }
    }
}