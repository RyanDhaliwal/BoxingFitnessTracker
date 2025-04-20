using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gimel.Pages
{
    public class SearchModel : PageModel
    {
        
        public class SearchData
        {
            public string Name { get; set; }
            public string Power { get; set; }
            public string PowerSpeed { get; set; }
            public string PunchTime { get; set; }
            public string RTimeSpeed { get; set; }
            public string RHand { get; set; }
            public string LHand { get; set; }
            public string Both { get; set; }
        }
        public class PowerL
        {
            public string Name { get; set; }
            public string Power { get; set; }
            public string Speed { get; set; }
            public string RecievedTime { get; set; }
        }
        public class CountL
        {
            public string Name { get; set; }
            public string RHand { get; set; }
            public string LHand { get; set; }
            public string Both { get; set; }
            public string RecievedTime { get; set; }
        }
        public class ReactionL
        {
            public string Name { get; set; }
            public string PunchTime { get; set; }
            public string Speed { get; set; }
            public string RecievedTime { get; set; }
        }
        public static List<PowerL> PowerLeaders { get; set; } = new List<PowerL>();
        public static List<CountL> CountLeaders { get; set; } = new List<CountL>();
        public static List<ReactionL> RTimeLeaders { get; set; } = new List<ReactionL>();


        public static string searchUserName { get; set; } = "None";
        public JsonResult OnGetResponse()
        {
            return new JsonResult(searchUserName);
        }
        public void OnPost(string searchusername)
        {
            searchUserName = searchusername;

            PowerLeaders = DAC.SearchPower(searchUserName);
            CountLeaders = DAC.SearchCount(searchUserName);
            RTimeLeaders = DAC.SearchRTime(searchUserName);
            
            
        }
        public void OnGet()
        {
            searchUserName = "None";
            
        }
        public JsonResult OnGetSearchShow()
        {
            var response = new
            {
                PowerLeaders,
                CountLeaders,
                RTimeLeaders
            };
            return new JsonResult(response);
        }
    }
}
