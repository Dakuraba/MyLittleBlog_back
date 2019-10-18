using MyLittleBlog_back.Domain.Command.Command;
using MyLittleBlog_back.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleBlog_back.Domain.Command.Handler
{
    public class DeletePostCommandHandler : ICommandHandler<DeletePostCommand, CommandResponse>
    {
        public DeletePostCommand _command;

        public DeletePostCommandHandler(DeletePostCommand command)
        {
            _command = command;
        }
        
        public async Task<CommandResponse> Execute()
        {
            var response = new CommandResponse()
            {
                Success = false
            };
            try
            {
                var item = MockBlogDb
                    .Posts
                    .FirstOrDefault(p => p.ID == _command.Id);

                if (item != null)
                {
                    MockBlogDb.UniquePostId--;
                    MockBlogDb.Posts.Remove(item);

                    response.ID = item.ID;
                    response.Success = true;
                    response.Message = "Delete post.";
                }
            }
            catch
            { 
                //log error
            }

            return response;
        }
    }
}
