using System;

namespace BookStore.Domain
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

        public BaseEntity()
        {
            this.CreateTime = DateTime.Now;
            this.UpdateTime = DateTime.Now;
        }
    }
}