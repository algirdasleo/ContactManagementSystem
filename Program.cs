/*
Simple contact management system.
- Person class - first name, last name and email properties.
- Contact class - first name, last name, email, phone number and address properties.
- IContactManager interface - AddContact, UpdateContact, DeleteContact and SearchContacts methods.
*/
using System;

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