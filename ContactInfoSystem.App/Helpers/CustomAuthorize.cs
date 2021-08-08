using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace ContactInfoSystem.App.Helpers
{
    public class CustomAuthorize : Attribute, IAuthorizationFilter
    {
        public string Roles { get; set; }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string[] roles = Roles.Split(',');
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                bool isPresent = false;
                for (int i = 0; i < roles.Length; i++)
                {
                    if (context.HttpContext.User.IsInRole(roles[i]))
                    {
                        isPresent = true;
                    }
                }
                if (!isPresent)
                {
                    context.Result = new RedirectToActionResult("Unauthorize", "Login", new { area = "" });
                }

            }
            else
            {
                context.Result = new RedirectToActionResult("Index", "Login", new { area = "" });
            }

        }
    }
}
