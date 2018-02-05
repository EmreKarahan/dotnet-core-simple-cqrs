using System;
using Simple.Cqrs.Aggregate;
using Simple.Cqrs.Repository;

namespace Simple.Cqrs.Command
{
    public class CreateTaskCommandHandler : ICommandHandler<CreateTaskCommand>
    {
        private readonly IWriteRepository<Task> writeRepository;

        public CreateTaskCommandHandler(  IWriteRepository<Task> writeRepository)
        {
            this.writeRepository = writeRepository ?? throw new ArgumentNullException(nameof(writeRepository));
        }

        public void Execute(CreateTaskCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            if (string.IsNullOrEmpty(command.Title))
            {
                throw new ArgumentException("Title is not specified", nameof(command));
            }

            var task = new Task
            {
                Title = command.Title,
                UserName = command.UserName,
                IsCompleted = command.IsCompleted,
                CreatedDate = command.CreatedOn,
                LastUpdatedDate = command.UpdatedOn
            };

            writeRepository.Add(task);

            writeRepository.Save();
        }

    }
}
