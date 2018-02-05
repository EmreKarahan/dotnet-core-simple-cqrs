using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simple.Cqrs.Aggregate
{
    public class Task 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; } 
        public bool IsCompleted { get; set; } 
        public DateTime  CreatedDate { get; set; } 
        public DateTime  LastUpdatedDate { get; set; } 

        public override string ToString()
        {
            return String.Format($"task=> {nameof(Id)}:{Id}, {nameof(Title)}:{Title}, {nameof(UserName)}:{UserName}, {nameof(IsCompleted)}:{IsCompleted}, {nameof(CreatedDate)}:{CreatedDate}, {nameof(LastUpdatedDate)}:{LastUpdatedDate}");
        }
    }
}
