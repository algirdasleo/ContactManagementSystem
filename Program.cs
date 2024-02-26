
namespace ContactManagementSystem{
    
    public class Person 
    { // klase skirta zmoniu informacijos vientisumui
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        
        public Person(string firstName, string lastName, string email)
        { // konstruktorius
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }


}