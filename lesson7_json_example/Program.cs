using System.Text.Json; // JSON

namespace lesson7_json_example
{
    class Person
    {
        private string name;
        private int age;

        public Person(string name, int age) {
            this.name = name;
            this.age = age;
        }

        public string Name { get { return name; } set { name = value; } } // just leaving it get; set; creates a backfield
        public int Age { get { return age; } set { age = value; } }
    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Person p = new Person("Abc",20);
            string res = JsonSerializer.Serialize(p); // only takes publicly available properties!
            // remove any properties/public getters/setters and the Json will exclude them. Then they're lost.
            // Bummer.

            Person q = JsonSerializer.Deserialize<Person>(res);
        }
    }
}
