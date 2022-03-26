namespace API.Entities
{
    public class BaseEntity
    {
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;

    }
}