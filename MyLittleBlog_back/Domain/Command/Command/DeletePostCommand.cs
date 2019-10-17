using MyLittleBlog_back.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleBlog_back.Domain.Command.Command
{
    public class DeletePostCommand : ICommand<CommandResponse>
    {
        public int Id { get; private set; }

        public DeletePostCommand(int id)
        {
            Id = id;
        }
            
    }
}
