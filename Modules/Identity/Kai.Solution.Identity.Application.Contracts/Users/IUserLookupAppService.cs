﻿using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Users;

namespace Kai.Solution.Identity
{
    public interface IUserLookupAppService : IApplicationService
    {
        Task<UserData> FindByIdAsync(Guid id);

        Task<UserData> FindByUserNameAsync(string userName);

        Task<ListResultDto<UserData>> SearchAsync(UserLookupSearchInputDto input);

        Task<long> GetCountAsync(UserLookupCountInputDto input);
    }
}
