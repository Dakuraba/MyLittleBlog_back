using Microsoft.AspNetCore.Mvc;
using MyLittleBlog_back.Domain.Command.Command;
using MyLittleBlog_back.Domain.Entity;
using PostDBManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleBlog_back.Domain.Command.Handler
{
    public class SavePostCommandHandler : BasePostRepository, ICommandHandler<SavePostCommand, CommandResponse>
    {
        private readonly SavePostCommand _command;
  

        public SavePostCommandHandler(IPostsRepository repo, SavePostCommand command) : base (repo)
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
                var item = await _repo.InsertPostAsync(_command.Post);

                response.ID = item.PostId;
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
