///@Author : Rupendra sharma
///
///
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;

namespace MessageService
{
    public class Client : IServiceContractCallback
    {
        
        
        /// <summary>
        /// Method send the information feed to the publisher service
        /// </summary>
        /// <param name="sender"> Sender name</param>
        /// <param name="title">Message title</param>
        /// <param name="messageBody">Message body</param>
        public void Publish(string sender, string title, string messageBody)
        {
            InstanceContext site = new InstanceContext(new Client());
             ServiceContractClient client = new ServiceContractClient(site);
            //Publish message to the Subscribers
            client.PublishMessage(sender, title, messageBody);
        }

        /// <summary>
        /// Callback method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="title"></param>
        /// <param name="messageBody"></param>
        public void SendMessage(string sender, string title, string messageBody)
        {
            Console.WriteLine("New message(Sender: {0}, \n Message subject: {1} \n Message: {2})", sender, title, messageBody);
        }
    }
}