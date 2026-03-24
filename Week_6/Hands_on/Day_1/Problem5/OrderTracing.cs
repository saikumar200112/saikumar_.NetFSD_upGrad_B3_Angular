using System;using System.IO;using System.Threading.Tasks;using System.Net.Http;using System.Diagnostics;using System.Reflection;namespace ConsoleApp8{    class Program    {        static async Task Main(string[] args)        {
            string order_trace = "order_trace.txt";
            TextWriterTraceListener fileLog = new TextWriterTraceListener(order_trace);

            Trace.Listeners.Add(fileLog);
            Trace.AutoFlush = true;

            Trace.WriteLine("start order processing");
            try
            {
                ProcessOrder();
                Trace.TraceInformation("Order completed successfully");

            }
            catch (Exception ex)
            {
                Trace.TraceError($"[Message]:{ex.Message}");
            }
            Console.WriteLine("Processing Finished");
            Trace.Flush();

            Console.ReadLine();        }
        static void ProcessOrder()
        {
            Trace.WriteLine("step 1: Validating Order");
            Trace.WriteLine("step 2: Processing Payment");
            Trace.WriteLine("step 3: Updating Inventory");
            throw new Exception("database connection during inventory update");
            Trace.WriteLine("step 4: Generating Invoice");
        }


    }
}