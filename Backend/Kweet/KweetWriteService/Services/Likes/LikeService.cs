﻿using AutoMapper;
using Kweet.Data;
using KweetWriteService.DTOs.LikeDTO;
using KweetWriteService.Models;
using MassTransit;
using MassTransit.Clients;
using SharedClasses;
using SharedClasses.Likes;

namespace KweetWriteService.Services.Likes
{
    public class LikeService : ILikeService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IRequestClient<WriteLikeDTO> _client;


        public LikeService(DataContext context, IMapper mapper, IRequestClient<WriteLikeDTO> writeLikeDTO)
        {
            _dataContext = context;
            _mapper = mapper;
            _client = writeLikeDTO;
        }

        public async Task<bool> LikeKweet(PostLikeKweetDTO dto)
        {
            PostLikeKweetDTO res = new PostLikeKweetDTO();
            LikeStatus likeStatus;

            try
            {
                if (!_dataContext.Kweets.Any(k => k.Id.ToString() == dto.KweetId)) throw new Exception("Kweet id does not exist");

                if (_dataContext.Likes.Any(k => k.KweetID == dto.KweetId && k.UserID == dto.UserId))
                {
                    _dataContext.Remove(_dataContext.Likes.Single(k => k.KweetID == dto.KweetId && k.UserID == dto.UserId));
                    _dataContext.SaveChanges();
                    likeStatus = LikeStatus.DELETE;
                }
                else
                {
                    LikeModel like = _mapper.Map<LikeModel>(dto);
                    _dataContext.Likes.Add(like);
                    _dataContext.SaveChanges();
                    likeStatus = LikeStatus.CREATE;
                }

                WriteLikeDTO rabbit = new WriteLikeDTO
                {
                    KweetId = dto.KweetId,
                    UserId = dto.UserId,
                    status = likeStatus
                };

                var response = await _client.GetResponse<MassTransitResponse>(rabbit);

                if (!response.Message.Succes) throw new Exception();

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }
    }
}