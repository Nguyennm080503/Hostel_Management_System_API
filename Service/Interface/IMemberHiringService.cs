﻿using Dtos.Hiring;

namespace Service.Interface
{
    public interface IMemberHiringService
    {
        Task CreateMember(NewHiringMemberDto memberDto);
    }
}
