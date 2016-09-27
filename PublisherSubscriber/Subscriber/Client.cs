using MessageService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MessageService
{
    /// <summary>
    /// 
    /// </summary>
    class Client : IServiceContractCallback
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            
            InstanceContext site = new InstanceContext(null, new Client());
            ServiceContractClient client = new ServiceContractClient(site);

            //unique callback address so multiple clients can run on one machine
            WSDualHttpBinding binding = (WSDualHttpBinding)client.Endpoint.Binding;
            string clientcallbackaddress = binding.ClientBaseAddress.AbsoluteUri;
            clientcallbackaddress += Guid.NewGuid().ToString();
            binding.ClientBaseAddress = new Uri(clientcallbackaddress);
            

            //Subscribe.
            Console.WriteLine("Subscribing");
            client.Subscribe();

            Console.WriteLine();
            Console.WriteLine("Press ENTER to unsubscribe and shut down client");
            Console.ReadLine();

            Console.WriteLine("Unsubscribing");
            client.Unsubscribe();
        }

        /// <summary>
        /// Callback method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="title"></param>
        /// <param name="messageBody"></param>
        public void SendMessage(string sender, string title, string messageBody)
        {
            Console.WriteLine("New message arrived \n Sender: {0}, \n Message subject: {1} \n Message: {2})", sender, title, messageBody);
        }
    }
}
