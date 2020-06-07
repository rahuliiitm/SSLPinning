using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Logging;
using SSLPinningServer.Interfaces;
using SSLPinningServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSLPinningServer.Controllers
{
    [ApiController]
    [Route("post/v1")]
    public class CommentsController : ControllerBase
    {

        private IPostService _postService;
        public CommentsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(PostDetails), 200)]
        public async Task<IActionResult> Get(int id)
        {
            PostDetails post;
            try
            {
                post = await _postService.Get(id);
            }
            catch (KeyNotFoundException)
            {
                return new NotFoundResult();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return StatusCode(200, post);


        }

        [HttpGet]
        [Route("all")]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(PostDetails), 200)]
        public async Task<IActionResult> All()
        {
            List<PostDetails> posts;
            try
            {
                posts = await _postService.All();
            }
            catch (KeyNotFoundException)
            {
                return new NotFoundResult();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return StatusCode(200, posts);


        }
    }
}
