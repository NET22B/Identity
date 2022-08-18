namespace Identity.Models.Entities
{
#nullable disable
    public class Vehicle
    {
        public int Id { get; set; }
        public string MemberId { get; set; }
        public Member Member { get; set; }
    }
}
