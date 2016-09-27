using System;
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
            try
            {
                callback = OperationContext.Current.GetCallbackChannel<IServiceClientContract>();
                messageHandler = new MessageEventHandler(MessageEventCallBackHandler);
                MessageEvent += messageHandler;
            }
            catch (AddressAlreadyInUseException ex)
            {
                throw new FaultException("The client end point address is already in use, release the port or use different port");
            }
            catch (Exception ex)
            {
                throw new FaultException("Error in subscribe, details:" + ex.Message);
            }
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
            try
            {
                MessageEventArgs message = new MessageEventArgs();
                message.sender = sender;
                message.title = title;
                message.messageBody = messageBody;
                //execute the event
                MessageEvent(this, message);
            }
            catch (FaultException fex)
            {
                throw new FaultException(fex.Message);
            }
            catch (Exception ex)
            {
                throw new FaultException("Not able to publish to the client, reson:" + ex.Message);
            }
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
