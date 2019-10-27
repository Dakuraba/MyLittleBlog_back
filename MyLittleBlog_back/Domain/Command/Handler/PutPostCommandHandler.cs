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
    public class PutPostCommandHandler : BasePostRepository, ICommandHandler<PutPostCommand, CommandResponse>
    {
        private PutPostCommand _command;

        public PutPostCommandHandler([FromServices] IPostsRepository repo, PutPostCommand command) : base(repo)
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
                var item = await _repo.UpdatePostAsync(_command.Post.PostId.ToString(), _command.Post);

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

                response.ID = _command.Post.PostId;
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
