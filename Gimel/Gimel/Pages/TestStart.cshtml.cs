using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gimel.Pages
{

    public class TestStartModel : PageModel
    {

        public static string TestStart { get; set; } = "NotStarted";
        public JsonResult OnGetStartPower() 
        {
            TestStart = "Power";
            return new JsonResult(TestStart.ToString());
        }
        public JsonResult OnGetStartReact()
        {
            TestStart = "React";

            return new JsonResult(TestStart.ToString());
        }
        public JsonResult OnGetStartCount()
        {
            TestStart = "Count";

            return new JsonResult(TestStart.ToString());
        }
        public JsonResult OnGetReset() 
        {
            TestStart = "NotStarted";
            return new JsonResult(TestStart.ToString());
        }
        public JsonResult OnGetResponse()
        {
            return new JsonResult(TestStart.ToString());
        }
    }
}
