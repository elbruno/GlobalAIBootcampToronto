using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class bot : IBot
    {
        public async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
        {
          if (turnContext.Activity.Type == ActivityTypes.Message)
            {
                await turnContext.SendActivityAsync($"You said {turnContext.Activity.Text}");
            }
        }
    }
}
