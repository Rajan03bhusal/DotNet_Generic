using GenericProject.Model;
using GenericProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenericProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IRepository<Blog> _BlogRepository;

        public BlogController(IRepository<Blog> BlogRepository)
        {
            _BlogRepository = BlogRepository;
        }

        [HttpGet]
        public async Task <IActionResult> GetAllBlog()
        {
            var blogs = await _BlogRepository.GetAllAsync();
            return Ok(blogs);
        }

        [HttpPost]
        public async Task <IActionResult> AddBlog([FromBody] Blog blog)
        {
            var BlogEntity = new Blog()
            {
                Title = blog.Title,
                Description = blog.Description,
                CreatedAt = DateTime.Now
            };
            var AddedBlog = await _BlogRepository.AddAsync(BlogEntity);

            return Ok(new
            {
                AddedBlog,
                message="Blog Added Successfully"

            });
        }

        [HttpPut]

        public async Task<IActionResult> EditBlog(int id, [FromBody] Blog blog)
        {
            var blogEntity = await _BlogRepository.GetByIdAsync(id);
            if (blogEntity == null)
            {
                return NotFound();
            }
            blogEntity.Title = blog.Title;
            blogEntity.Description = blog.Description;
            await _BlogRepository.UpdateAsync(blogEntity);

            return Ok(new
            {
                message = "Blog Updated Successfully"
            });

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var blogEntity = await _BlogRepository.GetByIdAsync(id);
            if (blogEntity == null)
            {
                return NotFound();
            }

            await _BlogRepository.DeleteAsync(blogEntity);
            return Ok(new
            {
                message = "Blog Deleted Successfully"
            });

        }
    }

}
