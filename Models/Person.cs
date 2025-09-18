namespace HostingSystem.Models
{
    public class Person
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Fullname => $"{Name} {LastName}".ToUpper();
        public Person(string name) => Name = name;
        public Person(string name, string lastname) { Name = name; LastName = lastname; }
    }
}