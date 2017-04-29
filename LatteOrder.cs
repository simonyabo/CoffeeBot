using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.FormFlow;
#pragma warning disable 649

//The LatteOrder is the simple form you want to fill out. It must be serializable so the bot can be stateless.
// The order of fields defines the default order in which questions will be asked. 
// Enumerations shows the legal options for each field in the SandwichOrder and the order is the order values will be presented 
// in a conversation.

namespace Bot_Application1
{

    public enum CoffeeOptions
    {
        Esspresso, Americano, Latte, Machiatto, Seasonal
    }
    public enum SizeOptions
    {
        Tall, Grande, Venti
    };
    public enum FlavorOptions
    {
        Mocha, Caramel, Vanilla, CinnamonDolce, Hazelnut, ToffeeNut, Peppermint, Rasberry, Classic
    };
    public enum ExtraShotOptions
    {
        One, Two, Three, Four, Five
    };

    [Serializable]
    [Template(TemplateUsage.NotUnderstood, "I do not understand \"{0}\".", "Try again, I don't get \"{0}\".")]
    public class LatteOrder
    {
        [Prompt("What kind of {&} would you like?")]
        public CoffeeOptions Coffee;
        
        [Prompt("What {&} would you like? {||}")]
        public SizeOptions? Size;

        [Optional]
        [Prompt("How about a {&} or two? {||}",ChoiceFormat ="{1}")]
        public List<FlavorOptions> Flavor;

        [Optional]
        public ExtraShotOptions? ExtraShots;

        public static IForm<LatteOrder> BuildForm()
        {
            return new FormBuilder<LatteOrder>()
                .Message("Welcome to the Coffee Order Bot!")
                .Build();
        }
    };
}