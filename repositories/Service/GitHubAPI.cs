using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Refit;

namespace repositories.Service
{
	//[Headers("Content-Type: application/json")]
    public interface IGitHubAPI
    {
		[Get("/search/repositories?q={language}&sort={sort}&page={page}")]
        Task<string> GetRepositories(string language, string sort, string page);

    }
}

