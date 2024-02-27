using System;

namespace ContactManagementSystem{
    
    public class Person 
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Person(string firstName, string lastName, string email)
        { 
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
    
    public class Contact : Person 
    {
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public Contact(string firstName, string lastName, string email, string phoneNumber, string address)
            : base(firstName, lastName, email)
        {
            PhoneNumber = phoneNumber;
            Address = address;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person("FirstName", "LastName", "pvz@email.com");
            Contact c = new Contact("Vardas", "Pavarde", "pvz@email.com", "+37012345678", "Vasaros g. 5");
            
            Console.WriteLine($"Person: \n{p.FirstName} {p.LastName} {p.Email}");
            Console.WriteLine($"Contact: \n{c.FirstName} {c.LastName}, {c.Email}. More info: {c.PhoneNumber}, {c.Address}");

        }
    }
}