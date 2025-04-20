using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Gimel.Pages
{
    public class PunchPower : PageModel
    {
        public static string TestDone { get; set; } = "No";
        public string PunchPowerData { get; set; } = "0";
        public static string UserName { get; set; }

        public void OnGet()
        {
            PunchPowerData = "0";
            UserName = null;
        }
        public JsonResult OnGetResponse()
        {
            return new JsonResult(UserName);
        }
        public JsonResult OnGetPowerTest()
        {
            if(TestDone == "Yes")
            {
                PunchPowerData = DAC.GetPunchPower();
                TestDone = "No";
            }
            
            return new JsonResult(PunchPowerData);
        }
        public JsonResult OnGetReset()
        {
            TestStartModel.TestStart = "NotStarted";
            PunchPowerData = "0";
            UserName = null;
            return new JsonResult(0);
        }

        public void OnPost(string nameInput)
        {
            UserName = nameInput;
        }

    }

}
