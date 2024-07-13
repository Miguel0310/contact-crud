using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
            if (contact == null)
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

        public void SaveContact()
        {
            using (StreamWriter file = new StreamWriter("Contact.txt"))
            {
                if (File.Exists("Contact.txt"))
                {
                    string opcao = "y";
                    Console.WriteLine("Deseja sobrescrivir o arquivo?: (y/n) ");
                    opcao = Console.ReadLine();

                    if (opcao.Equals("y"))
                    {
                        foreach (var contact in contacts)
                        {
                            file.WriteLine($"{contact.Name}, {contact.Description}");
                        }
                        Console.WriteLine("Arquivo salvo");
                    }
                    else
                    {
                        Console.WriteLine("Arquivo não modificado");
                    }
                }
            }
        }
        public void LoadContact()
        {
            if (File.Exists("Contact.txt"))
            {
                using (StreamReader file = new StreamReader("Contact.txt"))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        var data = line.Split(",");
                        var contact = new Contact()
                        {
                            Name = data[0],
                            Description = data[1]

                        };
                        contacts.Add(contact);
                    }
                }
            }
        }
        /// <summary>
        /// Ordenar de forma asc e desc
        /// </summary>
        /// <param name="order">caso for null, return asc</param>   
        public void OrderContact(string? order)
        {
            if (order == null || order.Equals("name", StringComparison.OrdinalIgnoreCase))
            {
                if (order.Equals("desc", StringComparison.OrdinalIgnoreCase))
                {
                    contacts = contacts.OrderByDescending(c => c.Name).ToList();

                }
                else
                {
                    contacts = contacts.OrderBy(c => c.Name).ToList();
                }

            }
            else if (order.Equals("description", StringComparison.OrdinalIgnoreCase))
            {
                if (order.Equals("desc", StringComparison.OrdinalIgnoreCase))
                {
                    contacts = contacts.OrderByDescending(c => c.Description).ToList();
                }
                else
                {
                    contacts = contacts.OrderBy(c => c.Description).ToList();
                }
            }

            foreach (var contact in contacts)
            {
                Console.WriteLine(contact);
            }
        }

        public void FilterContact(string filterBy, string filterValue)
        {
            IEnumerable<Contact> filteredContact = contacts;

            if (filterBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                filteredContact = contacts.Where(c => c.Name.Contains(filterValue, StringComparison.OrdinalIgnoreCase));
            }
            else if (filterBy.Equals("Description", StringComparison.OrdinalIgnoreCase))
            {
                filteredContact = contacts.Where(c => c.Description.Contains(filterValue, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                Console.WriteLine("Valor não esperado");
                return;
            }
            foreach (var contact in filteredContact)
            {
                Console.WriteLine(contact);
            }
        }

        public void ImportContact()
        {
            if (!File.Exists("contact.csv"))
            {
                Console.WriteLine("Arquivo não encontrado");
            }

            using (var reader = new StreamReader("Contact.csv"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var values = line.Split(',');

                    if (values.Length > 0)
                    {
                        var contact = new Contact()
                        {
                            Name = values[0],
                            Description = values[1]
                        };
                        contacts.Add(contact);
                    }
                    else
                    {
                        Console.WriteLine("Formato invalido");
                    }
                    
                }
            }

        }

        public void ExportContact()
        {
            using (var writer = new StreamWriter("Contact.csv"))
            {
                foreach (var contact in contacts)
                {
                    writer.WriteLine($"{contact.Name},{contact.Description}");
                }
            }
        }
    }

}
