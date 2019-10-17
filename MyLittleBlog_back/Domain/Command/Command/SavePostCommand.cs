using MyLittleBlog_back.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleBlog_back.Domain.Command.Command
{
    public class SavePostCommand : ICommand<CommandResponse>
    {
        public Post Post { get; private set; }

        public SavePostCommand(Post item)
        {
            Post = item;
        }
    }
}
