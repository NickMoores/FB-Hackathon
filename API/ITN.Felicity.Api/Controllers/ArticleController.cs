﻿using ITN.Felicity.Api.Models;
using ITN.Felicity.Domain;
using ITN.Felicity.Domain.Repositories;
using ITN.Felicity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ITN.Felicity.Api.Controllers
{
    [EnableCors(origins: "http://mywebclient.azurewebsites.net", headers: "*", methods: "*")]
    public class ArticleController : ApiController
    {
        private readonly IArticleRepository _repo;
        private readonly IUnitOfWork _unitOfWork;

        public ArticleController(IArticleRepository repo, IUnitOfWork unitOfWork)
        {
            this._repo = repo;
            this._unitOfWork = unitOfWork;
        }


        public async Task<List<Article>> Get()
        {
            return await _repo.Get();
        }

        public async Task<Article> Get([FromUri]Guid id)
        {
            return await this._repo.FindByIdAsync(id);
        }
      

        // POST api/values
        public async Task Post(ArticleModel am)
        {
            Article article = await _repo.FindByUrlAsync(am.Url);
            if(article == null)
            {
                article = new Article(Guid.NewGuid(), am.Url);
                _repo.Add(article);
                await this._unitOfWork.SaveChangesAsync();
            }
            
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
