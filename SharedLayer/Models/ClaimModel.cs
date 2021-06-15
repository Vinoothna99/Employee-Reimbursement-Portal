using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.Models
{
    public class ClaimModel
    {
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue{ get; set; }
        public string Date { get; set; }
        public string Currency { get; set; }
        public string ReceiptPhotoFileName { get; set; } 
        public string ClaimPhase{ get; set; }= "To Be Processed";
        public string isApproved{ get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedValue { get; set; }
        public string InternalNotes { get; set; }

    }
}
