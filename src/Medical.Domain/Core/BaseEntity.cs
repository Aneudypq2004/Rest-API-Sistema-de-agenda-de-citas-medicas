namespace Medical.Domain.Core
{
    public class BaseEntity
    {
        public int Id { get; set; }  

        public DateTime DateCreation { get; set; }

        public bool Deleted { get; set; }

        public bool DateDeleted { get; set; }
    }
}
