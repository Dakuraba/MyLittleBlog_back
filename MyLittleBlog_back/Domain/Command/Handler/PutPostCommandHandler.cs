using MyLittleBlog_back.Domain.Command.Command;
using MyLittleBlog_back.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleBlog_back.Domain.Command.Handler
{
    public class PutPostCommandHandler : ICommandHandler<PutPostCommand, CommandResponse>
    {
        private PutPostCommand _command;

        public PutPostCommandHandler(PutPostCommand command)
        {
            _command = command;
        }

        public CommandResponse Execute()
        {
            var response = new CommandResponse()
            {
                Success = false
            };

            try
            {
                var item = MockBlogDb
                    .Posts
                    .FirstOrDefault(p => p.ID == _command.Post.ID);

                if (item != null)
                {
                    item.PostContent = _command.Post.PostContent;
                    item.PostDate = _command.Post.PostDate;
                    item.PostTitle = _command.Post.PostTitle;

                }
                else
                {
                    //error
                }

                response.ID = item.ID;
                response.Success = true;
                response.Message = "Saved post.";
            }
            catch
            {
                //log error
            }

            return response;
        }
    }
}
