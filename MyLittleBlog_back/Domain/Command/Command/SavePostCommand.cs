using MyLittleBlog_back.Domain.Entity;
using PostDBManager.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleBlog_back.Domain.Command.Command
{
    public class SavePostCommand : ICommand<CommandResponse>
    {
        public PostDTO Post { get; private set; }

        public SavePostCommand(PostDTO item)
        {
            Post = item;
        }
    }
}
