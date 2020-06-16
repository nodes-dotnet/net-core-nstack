﻿using NStack.Models;
using NStack.Repositories;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NStack.Services.Implementation
{
    public class NStackLocalizeService : INStackLocalizeService<ResourceItem>
    {
        private readonly INStackRepository _repository;
        public NStackLocalizeService(INStackRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));
            _repository = repository;
        }

        public async Task<DataWrapper<List<ResourceData>>> GetLanguages(NStackPlatform platform)
        {
            var req = new RestRequest($"api/v2/content/localize/resources/platforms/{platform.ToString().ToLower()}");
            return await _repository.DoRequest<DataWrapper<List<ResourceData>>>(req);
        }

        public async Task<DataMetaWrapper<ResourceItem>> GetResource(int id)
        {
            var req = new RestRequest($"/api/v2/content/localize/resources/{id}");
            return await _repository.DoRequest<DataMetaWrapper<ResourceItem>>(req);
        }
    }
}
