using MyContactApp;

int options = 0;
Console.WriteLine("Selecione uma opção: ");
List<Contact> contacts = new List<Contact>();
Crud crud = new Crud();




while (options != 12)
{
    Console.WriteLine("1. Agregar Contacto\r\n" + //Feito
                      "2. Eliminar Contacto\r\n" + //Feito
                      "3. Buscar Contacto\r\n" +   //Feito
                      "4. Listar Contactos\r\n" + //Feito
                      "5. Editar Contacto\r\n" + //Feito
                      "6. Guardar Contactos\r\n" +
                      "7. Cargar Contactos\r\n" +
                      "8. Ordenar Contactos\r\n" +
                      "9. Filtrar Contactos\r\n" +
                      "10. Importar Contactos\r\n" +
                      "11. Exportar Contactos\r\n" +
                      "12. Salir");
    options = int.Parse(Console.ReadLine());

    switch (options) { 
        case 1:

            Console.WriteLine("Inserir nome: ");
            string name = Console.ReadLine();
            Console.WriteLine("Inserir Descrição: ");
            string description = Console.ReadLine();

            crud.CreateContact(name, description);
            
            break;
        case 2:
            Console.WriteLine("Inserir nome do contato a eliminar: ");
            name = Console.ReadLine();
            crud.DeletedContact(name);
            break;
        case 3:
            Console.WriteLine("Inserir nome do contato a procurar: ");
            name = Console.ReadLine();
            crud.FindContact(name);
            break;
        case 4:
            crud.SearchContact();
            break;
        case 5:
            Console.WriteLine("Inserir nome a pesquisar: ");
            string oldName = Console.ReadLine();
            Console.WriteLine("Inserir nome: ");
            name = Console.ReadLine();
            Console.WriteLine("Inserir Descrição: ");
            description = Console.ReadLine();
            crud.EditContact(oldName, name, description);
            break;
        case 12:
            break;
    }
}