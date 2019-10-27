using System.Collections.Generic;
using System.Threading.Tasks;
using PostDBManager.DTOs;

namespace PostDBManager.Interface
{
    public interface IPostsRepository
    {
        /// <summary>
        /// send get query filtered by a jsonQuery to te database
        /// use async mecanism to ensure no blocking statment.
        /// </summary>
        /// <param name="jsonQuery">the filter query</param>
        /// <returns></returns>
        Task<IEnumerable<PostDTO>> FilterAsync(string jsonQuery);
        /// <summary>
        /// Retrive post with the given id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<PostDTO> GetAsync(string id);
        Task<PostDTO> InsertPostAsync(PostDTO contact);
        Task<IEnumerable<PostDTO>> SelectAllAsync();
        Task<PostDTO> UpdatePostAsync(string id, PostDTO post);
        Task DeletePostAsync(string id);
    }
}