namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {

        

            var service = new ContactService();

            service.AddContact(new Contact
            {
                Id = 1,
                Name = "Hari",
                Email = "hari@gmail.com",
                Phone = "9999999999"
            });

          
            Console.WriteLine("After Add:");
            foreach (var c in service.GetAllContacts())
            {
                Console.WriteLine($"{c.Name}");
            }

     
            service.UpdateContact(new Contact
            {
                Id = 1,
                Name = "Hari Kumar",
                Email = "hari123@gmail.com",
                Phone = "8888888888"
            });

          
            Console.WriteLine("\nAfter Update:");
            foreach (var c in service.GetAllContacts())
            {
                Console.WriteLine($"{c.Name}");
            }

           
            service.DeleteContact(1);

            
            Console.WriteLine("\nAfter Delete:");
            var list = service.GetAllContacts();

            if (list.Count == 0)
            {
                Console.WriteLine("No Contacts Found");
            }
        }
        }
    }

