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
    public class DeletePostCommandHandler : BasePostRepository, ICommandHandler<DeletePostCommand, CommandResponse>
    {
        public DeletePostCommand _command;

        public DeletePostCommandHandler([FromServices] IPostsRepository repo, DeletePostCommand command) : base(repo)
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
                await _repo.DeletePostAsync(_command.Id.ToString());

                response.ID = _command.Id;
                response.Success = true;
                response.Message = "Delete post.";
            }
            catch
            { 
                //log error
            }

            return response;
        }
    }
}
