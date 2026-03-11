namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter First Number");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Second Number");
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Operater (+ - * /)");
            char op = char.Parse(Console.ReadLine());
            int c = 0;

               switch (op)
            {
                     case '+':
                        c = a + b;
                        break;

                case '-':
                    c = a - b;
                    break;

                case '*':
                    c = a * b;
                    break;


                case '/':
                    c = a / b;
                    break;

                default:
                    Console.WriteLine("Invalid Operation");
                    Console.ReadLine();
                    return;
            }
            Console.WriteLine($"Final Result :{c}");
            Console.ReadLine();
              
    
        }
    }
}
