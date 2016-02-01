using System;
using System.ComponentModel.DataAnnotations;

namespace MasterDetail.WebApp.Models
{
    public class CodeVm
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public String Barcode { get; set; }

        [MaxLength(255)]
        public string QrCodeLine { get; set; }

        public DateTime ScanDateTime { get; set; }
    }
}