using System;

namespace Simple.Cqrs.Command
{
    public class CreateTaskCommand : ICommand
    {
        public string Title { get; set; }
        public string UserName { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
