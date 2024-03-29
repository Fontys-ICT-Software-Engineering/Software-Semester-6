﻿using Kweet.Services.Kweet;
using KweetWriteService.DTOs.KweetDTO;
using KweetWriteService.DTOs.LikeDTO;
using KweetWriteService.Models;
using KweetWriteService.Services.Likes;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace KweetWriteService.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpGet]
        public string test()
        {
            return "this works";
        }

        [HttpPost(Name = "LikeKweet")]
        public async Task<ActionResult<bool>> LikeKweet(PostLikeKweetDTO dto)
        {
            bool res = false;

            try
            {
                res = await _likeService.LikeKweet(dto);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Likes")]
        public List<LikeModel> GetLikes() 
        {
            try
            {
                return _likeService.GetLikesPerKweet();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        public void Delete(Guid id) 
        {
            try
            {
                _likeService.DeleteLike(id);

            }
            catch (Exception)
            {

                throw;
            } 
        }
    }
}
