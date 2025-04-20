using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gimel.Pages
{
    public class ReactionTimeModel : PageModel
    {
        public static string TestDone { get; set; } = "No";
        public static string ReactionTimeData { get; set; } = "0";
        public static string UserName { get; set; } = "None";

        public void OnGet()
        {
            ReactionTimeData = "0";
            UserName = "None";
        }
        public JsonResult OnGetResponse()
        {
            return new JsonResult(TestDone);
        }
        public JsonResult OnGetReactionTest()
        {
            if (TestDone == "Yes")
            {
                ReactionTimeData = DAC.GetReactTime();
                TestDone = "No";
                UserName = "None";
            }

            return new JsonResult(ReactionTimeData);
        }

        public JsonResult OnGetReset()
        {
            TestStartModel.TestStart = "NotStarted";
            ReactionTimeData = "0";
            UserName = "None";
            return new JsonResult("Reset successful");
        }

        public void OnPost(string rtimeNameInput)
        {
            UserName = rtimeNameInput;
        }
    }
}
