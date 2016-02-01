using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using MasterDetail.WebApp.Entity;
using MasterDetail.WebApp.Models;

namespace MasterDetail.WebApp.Controllers
{
    public class TrackingController : ApiController
    {
        private readonly IRepository _repository;
        public TrackingController()
        {
            _repository = new Repository();
        }

        public IEnumerable<TrackingVm> Get()
        {
            var list = _repository.Trackings.ToList();
            return list.Select(x => new TrackingVm { Id = x.Id, OrderDate = x.OrderDate, MoNum = x.MoNum, QrShift = x.QrShift, QrOperators = x.QrOperators, QrComments = x.QrComments });
        }

        public TrackingVm Get(int id)
        {
            var it = _repository.Get(id);
            return new TrackingVm { Id = it.Id, OrderDate = it.OrderDate, MoNum = it.MoNum, QrShift = it.QrShift, QrOperators = it.QrOperators, QrComments = it.QrComments };
        }

        public async Task<IHttpActionResult> PostTracking(QrTracking tracking)
        {
            if (tracking==null || !ModelState.IsValid)
                return BadRequest(ModelState);
        
            await _repository.SaveTrackingAsync(tracking);
            return Ok();
        }
    }
}
