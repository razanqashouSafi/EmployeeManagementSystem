namespace MyApp.Core.Models
{
    public class MainEntity
    {

        public int Id { get; set; }

        public DateTime CreateDate { get; set; }=DateTime.Now;

        public string CreateBy { get; set; } = "System";

        public DateTime? UpateDate { get; set; }

        public string? UpdateBy { get; set; }

        public bool? IsActive { get; set; } = true;



    }
}
