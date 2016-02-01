using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MasterDetail.WebApp.Entity
{
    public class QrTracking
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public DateTime OrderDate { get; set; }

        [MaxLength(255)]
        [Required]
        public string MoNum { get; set; }

        [MaxLength(255)]
        [Required]
        public string QrShift { get; set; }

        [MaxLength(255)]
        [Required]
        public string QrOperators { get; set; }

        [MaxLength(255)]
        public string QrComments { get; set; }

        public virtual ICollection<QrCode> QrCodes { get; set; }

        public QrTracking()
        {
            QrCodes = new List<QrCode>();
        }
    }
}