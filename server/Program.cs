using Grpc.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    class Program
    {
        const int port = 500051;
        static void Main(string[] args)
        {
            Server server = null;
            try
            {
                server = new Server()
                {
                    Ports = {new ServerPort("loaclhost",port,ServerCredentials.Insecure)}
                };
                server.Start();
                Console.WriteLine("The server is listening on the port: "+port);
                Console.ReadKey();

            }
            catch (IOException e)
            {
                Console.WriteLine("The server is failed to start: " +e.Message);

                throw;
            }
            finally
            {
                if (server != null)
                    server.ShutdownAsync().Wait();

            }
        }
    }
}
