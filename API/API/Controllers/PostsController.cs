﻿using API.Models;
using API.Repository;
using API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostsService _postsService;

        public PostsController(IPostsService postsService)
        {
            _postsService = postsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetAll()
        {
            return Ok(await _postsService.GetAllPosts());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPostById(Guid id)
        {
            var post = await _postsService.GetPostById(id);
            if (post == null)
            {
                return NotFound("post not found");
            }
            return Ok(post);
        }

        //[HttpPost]
        //public async Task<ActionResult<List<Post>>> AddPost(Post post)
        //{
        //    _dataContext.Posts.Add(post);
        //    await _dataContext.SaveChangesAsync();

        //    return Ok(await _dataContext.Posts.ToListAsync());
        //}

        //[HttpPut]
        //public async Task<ActionResult<Post>> Put(Post request)
        //{
        //    var post = await _dataContext.Posts.FindAsync(request.Id);

        //    if (post == null)
        //    {
        //        return NotFound("post not found");
        //    }

        //    post.Id = request.Id;
        //    post.Title = request.Title;
        //    post.Description = request.Description;

        //    await  _dataContext.SaveChangesAsync();
        //    return Ok(post);
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<List<Post>>> DeletePost(Guid id)
        //{
        //    var post = await _dataContext.Posts.FindAsync(id);
        //    if (post == null)
        //    {
        //        return NotFound("post not found");
        //    }
        //    _dataContext.Posts.Remove(post);
        //    await _dataContext.SaveChangesAsync();
        //    return Ok(await _dataContext.Posts.ToListAsync());
        //}
    }
}
