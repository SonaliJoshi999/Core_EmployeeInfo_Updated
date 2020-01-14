using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Sol_Core_EmployeeInfo.Models;

namespace Sol_Core_EmployeeInfo.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("user-infocard")]
    public class UserTagHelper : TagHelper
    {
        #region Declaration
        private readonly IHtmlHelper htmlHelper = null;
        private const string ItemSourceAttributeName = "item-source";
        private const string ActionNameAttributeName = "action-name";
        private const string ControllerNameAttributeName = "controller-name";
        #endregion

        #region Constructor
        public UserTagHelper(IHtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
        }
        #endregion

        #region Property (Html Attribute)
        [HtmlAttributeName(ItemSourceAttributeName)]
        public ModelExpression ItemSource { get; set; }

        [HtmlAttributeName(ControllerNameAttributeName)]
        public String ControllerName { get; set; }

        [HtmlAttributeName(ActionNameAttributeName)]
        public String ActionName { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        #endregion
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            //Contextualize the html helper
            (htmlHelper as IViewContextAware).Contextualize(ViewContext);

            var userTagHelperModelObj = new UserTagHelperModel()
            {
                UserList = ItemSource.Model as List<UserModel>,
                ActionName = ActionName,
                ControllerName = ControllerName
            };

            var usersCardTemplate = await htmlHelper.PartialAsync("~/Views/Shared/_UserTagHelperPartialView.cshtml", userTagHelperModelObj);

            output.Content.SetHtmlContent(usersCardTemplate);

            //return base.ProcessAsync(context, output);
        }
    }
}
