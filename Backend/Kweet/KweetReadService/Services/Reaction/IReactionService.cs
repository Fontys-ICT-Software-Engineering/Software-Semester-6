﻿using KweetReadService.DTOs.ReactionDTO;
using KweetReadService.Models;
using SharedClasses.Reaction;

namespace KweetReadService.Services.Reaction
{
    public interface IReactionService
    {
        public Task<bool> CreateReactionKweet(WriteCreateReactionKweet dto);

        public List<GetReactionDTO> GetReactionsByTweet(string kweetId);

        public Task<bool> UpdateReactionKweet();

        public bool DeleteReactionKweet(Guid Id);
        public Task GDPRDelete(List<string> ids, string Id);


    }
}
