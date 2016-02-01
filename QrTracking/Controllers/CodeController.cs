using System.Collections.Generic;
using System.Web.Http;
using MasterDetail.WebApp.Entity;
using MasterDetail.WebApp.Models;

namespace MasterDetail.WebApp.Controllers
{
    public class CodeController : ApiController
    {
        private readonly IRepository _repository;
        public CodeController()
        {
            _repository = new Repository();
        }

        public IEnumerable<CodeVm> Get(int id)
        {
            return _repository.Codes(id);
        }

        public CodeVm Post(int id, CodeVm code)
        {
            var codeEntity = _repository.SaveCode(id, code.Barcode, code.QrCodeLine);
            return new CodeVm { Id = codeEntity.Id, Barcode = codeEntity.Barcode, QrCodeLine = codeEntity.QrCodeLine, ScanDateTime = codeEntity.ScanDateTime };
        }

        public void Delete(int id)
        {
            _repository.DeleteCode(id);
        }
        /*public QrTracking Get(int id)
        {
            return _repository.Get(id);
        }

        public async Task<IHttpActionResult> PostTracking(QrTracking tracking)
        {
            if (ModelState.IsValid)
            {
                await _repository.SaveTrackingAsync(tracking);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }*/
    }
}
