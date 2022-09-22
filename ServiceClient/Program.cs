using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClient {
    internal class Program {
        static void Main(string[] args) {
            CalculadoraService.CalculadoraServiceClient proxy = new CalculadoraService.CalculadoraServiceClient();
            try {               
                proxy.ClientCredentials.UserName.UserName = "test1";
                proxy.ClientCredentials.UserName.Password = "12345";

                // Call the Add service operation.
                double value1 = 100.00D;
                double value2 = 15.99D;
                double result = proxy.Sumar(value1, value2);
                Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

                // Call the Subtract service operation.
                value1 = 145.00D;
                value2 = 76.54D;
                result = proxy.Restar(value1, value2);
                Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);

                // Call the Multiply service operation.
                value1 = 9.00D;
                value2 = 81.25D;
                result = proxy.Multiplicar(value1, value2);
                Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

                // Call the Divide service operation.
                value1 = 22.00D;
                value2 = 7.00D;
                result = proxy.Dividir(value1, value2);
                Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);
                proxy.Close();
            } catch (TimeoutException e) {
                Console.WriteLine("Call timed out : {0}", e.Message);
                proxy.Abort();
            } catch (Exception e) {
                Console.WriteLine("Call failed:");
                while (e != null) {
                    Console.WriteLine("\t{0}", e.Message);
                    e = e.InnerException;
                }
                proxy.Abort();
            }

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }
    }
}
