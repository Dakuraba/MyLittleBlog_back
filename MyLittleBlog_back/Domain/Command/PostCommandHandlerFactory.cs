using Microsoft.Extensions.DependencyInjection;
using MyLittleBlog_back.Domain.Command.Command;
using MyLittleBlog_back.Domain.Command.Handler;
using MyLittleBlog_back.Domain.Entity;
using PostDBManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleBlog_back.Domain.Command
{
    public class PostCommandHandlerFactory : IPostCommandHandlerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public PostCommandHandlerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ICommandHandler<SavePostCommand, CommandResponse> Build(SavePostCommand command)
        {
            return new SavePostCommandHandler(_serviceProvider.GetService<IPostsRepository>(), command);
        }

        public ICommandHandler<DeletePostCommand, CommandResponse> Build(DeletePostCommand command)
        {
            return new DeletePostCommandHandler(_serviceProvider.GetService<IPostsRepository>(), command);
        }

        public  ICommandHandler<PutPostCommand, CommandResponse> Build(PutPostCommand command)
        {
            return new PutPostCommandHandler(_serviceProvider.GetService<IPostsRepository>(), command);
        }
    }
}
