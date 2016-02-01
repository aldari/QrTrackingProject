using System;
using System.ComponentModel.DataAnnotations;

namespace MasterDetail.WebApp.Entity
{
    public class QrCode
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public String Barcode { get; set; }

        [MaxLength(255)]
        public string QrCodeLine { get; set; }

        public DateTime ScanDateTime { get; set; }

        //public int QrTrackingId { get; set; }
        public virtual QrTracking Tracking { get; set; }
    }
}