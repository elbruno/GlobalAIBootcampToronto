using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.FormFlow;
using FormFlowBot.FormFlow;

namespace FormFlowBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        internal static IDialog<ReservaFlow> MakeRootDialog()
        {
            //To Call a FormDialog input the line below.
            return Chain.From(() => FormDialog.FromForm(ReservaFlow.BuildFrom));
        }
      
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
               
                await Conversation.SendAsync(activity, MakeRootDialog);
               
              
            }
         
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
              
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
              
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}