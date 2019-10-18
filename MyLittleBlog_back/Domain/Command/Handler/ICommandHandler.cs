using MyLittleBlog_back.Domain.Command.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleBlog_back.Domain.Command.Handler
{
    public interface ICommandHandler<in TCommand, TResult> where TCommand : ICommand<TResult>
    {
        Task<TResult> Execute();
    }
}
