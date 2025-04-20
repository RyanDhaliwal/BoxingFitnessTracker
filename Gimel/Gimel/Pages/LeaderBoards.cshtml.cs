using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gimel.Pages
{
    public class LeaderBoardsModel : PageModel
    {
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
        public void OnGet()
        {
            PowerLeaders.Clear();
            CountLeaders.Clear();
            RTimeLeaders.Clear();
        }
        public JsonResult OnGetPowerLeader()
        {
            PowerLeaders = DAC.GetPowerLeaders();
            return new JsonResult(PowerLeaders);
        }
        public JsonResult OnGetCountLeader()
        {
            CountLeaders = DAC.GetCountLeaders();
            return new JsonResult(CountLeaders);
        }
        public JsonResult OnGetReactionLeader()
        {
            RTimeLeaders = DAC.GetRTimeLeaders();
            return new JsonResult(RTimeLeaders);
        }
    }
}
