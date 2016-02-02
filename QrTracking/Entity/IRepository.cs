using System.Collections.Generic;
using System.Threading.Tasks;
using MasterDetail.WebApp.Models;

namespace MasterDetail.WebApp.Entity
{
    public interface IRepository
    {
        IEnumerable<QrTracking> Trackings { get; }

        Task<int> SaveTrackingAsync(QrTracking tracking);

        QrTracking Get(int id);


        IEnumerable<CodeVm> Codes(int id);

        QrCode SaveCode(int trackingId, string barcode, string qrCodeLine);

        void DeleteCode(int id);

        IEnumerable<TrackingSearchVm> SearchByCodebar(string part);
    }
}