using System.Collections.Generic;
using System.Web.Http;
using MasterDetail.WebApp.Entity;
using MasterDetail.WebApp.Models;

namespace MasterDetail.WebApp.Controllers
{
    public class SearchController : ApiController
    {
        private readonly IRepository _repository;
        public SearchController()
        {
            _repository = new Repository();
        }

        public IEnumerable<TrackingSearchVm> Get(string id)
        {
            return _repository.SearchByCodebar(id);
        }
    }
}
