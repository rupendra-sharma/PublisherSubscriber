///@Author : Rupendra sharma
///
///
using MessageService;
using System.Web.Mvc;

namespace InformationSource.Controllers
{
    /// <summary>
    /// Default controller for the Data feed generator 
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Index action
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Method publishes the feed to service
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="title"></param>
        /// <param name="messageBody"></param>
        /// <returns></returns>
        public ActionResult Publish(string sender, string title, string messageBody)
        {
            Client client = new Client();
            client.Publish(sender, title, messageBody);
            return Json(new 
            {
                StatusMessage = string.Format("message sent")
            }, JsonRequestBehavior.AllowGet); 
        }
    }
}