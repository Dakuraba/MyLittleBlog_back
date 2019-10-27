using MyLittleBlog_back.Domain.Command.Command;
using MyLittleBlog_back.Domain.Command.Handler;
using MyLittleBlog_back.Domain.Entity;

namespace MyLittleBlog_back.Domain.Command
{
    public interface IPostCommandHandlerFactory
    {
        ICommandHandler<DeletePostCommand, CommandResponse> Build(DeletePostCommand command);
        ICommandHandler<PutPostCommand, CommandResponse> Build(PutPostCommand command);
        ICommandHandler<SavePostCommand, CommandResponse> Build(SavePostCommand command);
    }
}