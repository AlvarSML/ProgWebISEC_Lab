using ASP6_SinAuth.Areas.Identity.Data;

namespace ASP6_SinAuth.Models.ViewModels
{
    public class TestModification
    {
        public string userId { get; set; }
        public DateTime testDate { get; set; }
        public string? comment { get; set; } 
        public string typeId { get; set; }
        public string labId { get; set; }
    }
}
