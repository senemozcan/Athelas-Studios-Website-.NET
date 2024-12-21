using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AthelasStudios.Infrastructure.TagHelpers
{
    [HtmlTargetElement("td", Attributes = "user-role")]
    public class UserRoleTagHelper : TagHelper
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityUser> _roleManager;

        [HtmlAttributeName("user-name")]
        public String? UserName { get; set; }
        public UserRoleTagHelper(UserManager<IdentityUser> userManager, RoleManager<IdentityUser> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var user = await _userManager.FindByNameAsync(UserName);
            TagBuilder ul = new TagBuilder("ul");

            var roles = _roleManager.Roles.ToList().Select( r => r.UserName); //BURAYI SONRA KONTROL ET!!

            foreach (var role in roles)
            {
                TagBuilder li = new TagBuilder("li");
                li.InnerHtml.Append($"{role} : {await _userManager.IsInRoleAsync(user,role)}");
                ul.InnerHtml.AppendHtml(li);
            }

            output.Content.AppendHtml(ul);
        }


    }
}