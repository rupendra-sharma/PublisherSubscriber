///@Author : Rupendra sharma
///
///
using System.ServiceModel;
namespace MessageService
{
    /// <summary>
    /// Publisher service
    /// </summary>
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerSession)]
    public class Service : IServiceContract
    {
        #region variables
        public static event MessageEventHandler MessageEvent;
        public delegate void MessageEventHandler(object sender, MessageEventArgs args);


        IServiceClientContract callback = null;
        MessageEventHandler messageHandler = null;
        #endregion


        /// <summary>
        /// Method used by Client to subscribe for the information feed
        /// </summary>
        public void Subscribe()
        {
            callback = OperationContext.Current.GetCallbackChannel<IServiceClientContract>();
            messageHandler = new MessageEventHandler(MessageEventCallBackHandler);
            MessageEvent += messageHandler;
        }

        
        /// <summary>
        /// Subscriber can use this method to unsubscribe from the feed
        /// </summary>
        public void Unsubscribe()
        {
            MessageEvent -= messageHandler;
        }


        /// <summary>
        /// Method send the information feed all the subscribers
        /// </summary>
        /// <param name="sender"> Sender name</param>
        /// <param name="title">Message title</param>
        /// <param name="messageBody">Message body</param>
        public void PublishMessage(string sender, string title, string messageBody)
        {
            MessageEventArgs message = new MessageEventArgs();
            message.sender = sender;
            message.title = title;
            message.messageBody = messageBody;
            //execute the event
            MessageEvent(this, message);
        }

        /// <summary>
        ///  Handle for publish event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args">Message parts</param>
        public void MessageEventCallBackHandler(object sender, MessageEventArgs args)
        {
            //Publish the new message
            callback.SendMessage(args.sender, args.title, args.messageBody);
        }
    }
}
