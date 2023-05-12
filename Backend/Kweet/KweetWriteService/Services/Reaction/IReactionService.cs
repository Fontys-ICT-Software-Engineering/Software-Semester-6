﻿using KweetWriteService.DTOs.ReactionDTO;

namespace KweetWriteService.Services.Reaction
{
    public interface IReactionService
    {
        public Task<bool> CreateReactionKweet(PostReactionKweetDTO dto);

        public  List<GetReactionDTO> GetReactionsByTweet(string kweetId);

        public Task<bool> DeleteReactionKweet(Guid Id);

    }

}
