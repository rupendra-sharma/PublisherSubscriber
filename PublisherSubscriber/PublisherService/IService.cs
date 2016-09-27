///@Author : Rupendra sharma
///
///
using System.ServiceModel;

namespace MessageService
{
    /// <summary>
    /// 
    /// </summary>
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples", SessionMode = SessionMode.Required, CallbackContract = typeof(IServiceClientContract))]
    public interface IServiceContract
    {
        [OperationContract(IsOneWay = false, IsInitiating = true)]
        void Subscribe();
        [OperationContract(IsOneWay = false, IsTerminating = true)]
        void Unsubscribe();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="title"></param>
        /// <param name="messageBody"></param>
        [OperationContract(IsOneWay = true)]
        void PublishMessage(string sender, string title, string messageBody);
    }
}
