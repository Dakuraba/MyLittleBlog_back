using MyLittleBlog_back.Domain.Command.Command;
using MyLittleBlog_back.Domain.Command.Handler;
using MyLittleBlog_back.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleBlog_back.Domain.Command
{
    public static class PostCommandHandlerFactory
    {
        public static ICommandHandler<SavePostCommand, CommandResponse> Build(SavePostCommand command)
        {
            return new SavePostCommandHandler(command);
        }

        public static ICommandHandler<DeletePostCommand, CommandResponse> Build(DeletePostCommand command)
        {
            return new DeletePostCommandHandler(command);
        }

        public static ICommandHandler<PutPostCommand, CommandResponse> Build(PutPostCommand command)
        {
            return new PutPostCommandHandler(command);
        }
    }
}
