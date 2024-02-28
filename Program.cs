/*
Simple contact management system.
- Person class - first name, last name and email properties.
- Contact class - first name, last name, email, phone number and address properties.
- IContactManager interface - AddContact, UpdateContact, DeleteContact and SearchContacts methods.
*/
using System;
using System.ComponentModel.DataAnnotations;
namespace ContactManagementSystem{
    public interface IContactManager
    {
        void AddContact(Contact contact);
        void UpdateContact(Contact contact);
        void DeleteContact(string email);
        List<Contact> SearchContacts(string keyword);
    }
    public class ContactManager : IContactManager
    {
        private List<Contact> _contacts = new List<Contact>();

        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
        }

        public void UpdateContact(Contact contact)
        {
            for(int i = 0; i < _contacts.Count; i++)
                if (_contacts[i].Email == contact.Email){
                    _contacts[i] = contact;
                    break;
                }
        }

        public void DeleteContact(string email)
        {
            for (int i = 0; i < _contacts.Count; i++){
                if (_contacts[i].Email == email){
                    _contacts.RemoveAt(i);
                    break;
                }
            }
        }

        public List<Contact> SearchContacts(string keyword)
        {
            var searchResults = new List<Contact>();
            for (int i = 0; i < _contacts.Count; i++){
                Contact c = _contacts[i];
                if (c.Address == keyword ||
                    c.FirstName == keyword ||
                    c.LastName == keyword ||
                    c.PhoneNumber == keyword ||
                    c.Email == keyword)
                    {
                        searchResults.Add(c);
                    }
            }
            return searchResults;
        }
    }
    public class Person 
    { 
        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(30, ErrorMessage = "First name cannot be longer than 30 characters.")]
        [MinLength(2, ErrorMessage = "First name cannot be shorter than 2 characters.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name can only contain letters.")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Last name is required.")]
        [MaxLength(30, ErrorMessage = "Last name cannot be longer than 30 characters.")]
        [MinLength(2, ErrorMessage = "Last name cannot be shorter than 2 characters.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name can only contain letters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
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
        [Required(ErrorMessage = "Phone number is required.")]
        [MaxLength(20, ErrorMessage = "Phone number cannot be longer than 20 characters.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "Address is required.")]
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
            ContactManager cm = new ContactManager();
            Contact contact1 = new Contact("Vardas", "Pavarde", "pvz@email.com", "+37012345678", "Vasaros g. 5");
            cm.AddContact(contact1);

            Contact contact2 = new Contact("Vardas1", "Pavarde1", "pvz1@email.com", "+37012345678", "Vasaros g. 5");
            cm.AddContact(contact2);

            var contactList = cm.SearchContacts("+37012345678");
            
            if (contactList.Count != 0)
            {
                Console.WriteLine("Found these contacts by your keyword:");
                foreach(var c in contactList)
                    Console.WriteLine($"{c.FirstName} {c.LastName}, {c.Email}. More info: {c.PhoneNumber}, {c.Address}");
            } else 
                Console.WriteLine("No contacts found.");
            
        }
    }
}