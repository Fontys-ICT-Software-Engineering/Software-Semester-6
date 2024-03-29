﻿using AuthService.DTOs;
using ProfileService.DTOs;

namespace ProfileService.Services
{
    public interface IProfileService
    {
        public Task RegisterUser(RegisterUserDTO dto);

        public Task<List<ProfileDTO>> getAllProfiles();

        public Task GDPRDelete(string Id);

    }
}
