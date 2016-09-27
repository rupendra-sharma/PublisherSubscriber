///@Author : Rupendra sharma
///
///
using System;
namespace MessageService
{
    /// <summary>
    /// Message even argument class
    /// </summary>
    public class MessageEventArgs
    {
        /// <summary>
        /// Message title
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// Message sender
        /// </summary>
        public string sender { get; set; }

        /// <summary>
        /// Message body
        /// </summary>
        public string messageBody { get; set; }
    }
}
