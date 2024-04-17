using RestSharp;
using System.Threading.Tasks;
#pragma warning disable CS1998
#pragma warning disable CS4014

namespace ExpenditureManagement.Logic
{
    public class MailLogic
    {
        private readonly static string baseUrl = "{MailSendingEndPoint}";

        public static async Task MailApi(string toEmail, string mailSubject, string mailbody)
        {
            try
            {
                RestClient restClient = new RestClient(baseUrl);
                restClient.Timeout = -1;
                RestRequest request = new RestRequest(Method.POST);
                request.AddJsonBody(new { ToMail = toEmail, MailSubject = mailSubject, MailBody = mailbody, RequestId = "Expense Management app" });
                Task.Run(() => { restClient.Execute(request); });
                return;
            }
            catch
            {
                return;
            }
        }
    }
}