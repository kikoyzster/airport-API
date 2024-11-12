using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace airport.ActionFilters
{
    public class RedirectToStartScreenAttribute : ActionFilterAttribute
    {
        private readonly List<string> _excludeActions = new List<string> { "Menu","Airport" }; // Exclude the Menu action

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Check if the current action is excluded
            if (!_excludeActions.Contains(filterContext.RouteData.Values["action"].ToString()))
            {
                // Check if the session data exists
                if (filterContext.HttpContext.Session.GetString("SelectedAirport") == null)
                {
                    // Redirect to the start screen
                    filterContext.Result = new RedirectResult("~/Home/Airport");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
