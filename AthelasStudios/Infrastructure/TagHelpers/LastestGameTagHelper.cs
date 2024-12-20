using Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Services.Contracts;

namespace AthelasStudios.Infrastructure.TagHelpers
{
    [HtmlTargetElement("div" , Attributes = "games")]
    public class LastestGameTagHelper : TagHelper
    {
        private readonly IServiceManager _manager;
        [HtmlAttributeName("number")]
        public int Number { get; set; }

        public LastestGameTagHelper(IServiceManager manager)
        {
            _manager = manager;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("class" , "my-3");

            TagBuilder h6 = new TagBuilder("h6");
            h6.Attributes.Add("class" , "lead");

            TagBuilder icon = new TagBuilder("i");
            icon.Attributes.Add("class" , "fa fa-box text-secondary");

            h6.InnerHtml.AppendHtml(icon);
            h6.InnerHtml.AppendHtml(" Lastest Products");

            TagBuilder ul = new TagBuilder("ul");
            var games = _manager.GameService.GetLastestGames(Number,false);
            foreach (Game game in games)
            {
                TagBuilder li = new TagBuilder("li");
                TagBuilder a = new TagBuilder("a");
                a.Attributes.Add("href", $"/games/get/{game.GameId}");
                a.InnerHtml.AppendHtml(game.GameName);

                li.InnerHtml.AppendHtml(a);
                ul.InnerHtml.AppendHtml(div);
                
            }

            div.InnerHtml.AppendHtml(h6);
            div.InnerHtml.AppendHtml(ul);
            output.Content.AppendHtml(div);

        }

    }
}