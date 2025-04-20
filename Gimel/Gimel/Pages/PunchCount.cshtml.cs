using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gimel.Pages
{
    public class PunchCountModel : PageModel
    {
        public static string TestDone { get; set; } = "No";
        public static string PunchCountData { get; set; } = "0";
        public static string UserName { get; set; }

        public void OnGet()
        {
            PunchCountData = "0";
            UserName = null;
        }
        public JsonResult OnGetResponse()
        {
            return new JsonResult(TestDone);
        }
        public JsonResult OnGetCountTest()
        {
            if (TestDone == "Yes")
            {
                PunchCountData = DAC.GetPunchCount();
                TestDone = "No";
            }

            return new JsonResult(PunchCountData);
        }
        public JsonResult OnGetReset()
        {
            TestStartModel.TestStart = "NotStarted";
            PunchCountData = "0";
            UserName = null;
            return new JsonResult(0);
        }
        
        public void OnPost(string nameInput)
        {
            UserName = nameInput;
        }
    }
}
