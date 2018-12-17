using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using System;


namespace FormFlowBot.FormFlow
{
    //Every Class in Bot Framework, we need to the annotation below. Every Class needs be Serializable.
    [Serializable]
    public class ReservaFlow
    {
        
        public Period Periods { get; set; }
        public Place Places { get; set; }

        [Prompt("Whats your name?")]
        public string Nome { get; set; }
        [Prompt("Whats your email?")]
        [Pattern(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        public string Email { get; set; }

        public enum Period
        {
            [Terms("Early","In the morning","Morning")]
            Morning=1,
            Afternoon,
            Night
        }

        public enum Place
        {
            Main = 1,
            StFloor,
            ndFloor
        }

        public static IForm<ReservaFlow> BuildFrom()
        {
            var form = new FormBuilder<ReservaFlow>();
            form.Configuration.DefaultPrompt.ChoiceStyle = ChoiceStyleOptions.Buttons;
            form.Message("Hi welcome, its a pleasure attended");

            form.OnCompletion(async (context, reserva) =>
            {

                await context.PostAsync("Your reservation is confirmed");
            });

            return form.Build();
        }
        
    }
}