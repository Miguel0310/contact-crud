using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContactApp
{
    public class Crud
    {

        List<Contact> contacts = new List<Contact>();

        public void CreateContact(string name, string description)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (description == null) throw new ArgumentNullException("description");

            var contact = new Contact { Name = name, Description = description };

            contacts.Add(contact);
            Console.WriteLine("Cadastro criado com sucesso");
        }

        public void SearchContact()
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact);
            }
        }

        public void DeletedContact(string nome)
        {
            var contact = contacts.FirstOrDefault(m => m.Name == nome);
            if (contact == null)
            {
                Console.WriteLine("Contato não encontrado");
            }
            else
            {
                contacts.Remove(contact);
                Console.WriteLine("Contato Removido com Sucesso");
            }
        }

        public void FindContact(string name)
        {
            var contact = contacts.FirstOrDefault(m => m.Name == name);
            if(contact == null)
            {
                Console.WriteLine("Contacto não encontrado");
            }
            else
            {
                Console.WriteLine(contact);
            }
        }

        public void EditContact(string oldName, string name, string description)
        {
            var contact = contacts.FirstOrDefault(m => m.Name == oldName);
            if (contact == null)
            {
                Console.WriteLine("Contato não encontrado");
            }
            else
            {
                contact.Name = name;
                contact.Description = description;
                Console.WriteLine("Edição feita com sucesso");
            }
        }
    }
}
