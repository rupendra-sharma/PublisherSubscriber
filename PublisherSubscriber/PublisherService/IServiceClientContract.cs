///@Author : Rupendra sharma
///
///
using System.ServiceModel;

namespace MessageService
{
    /// <summary>
    /// 
    /// </summary>
    public interface IServiceClientContract
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="title"></param>
        /// <param name="messageBody"></param>
        [OperationContract(IsOneWay = true)]
        void SendMessage(string sender, string title, string  messageBody);
    }
}
