using System;

namespace Simple.Cqrs.Command
{
    public class ChangeTaskStatusCommand : ICommand
    {
        public int TaskId { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
