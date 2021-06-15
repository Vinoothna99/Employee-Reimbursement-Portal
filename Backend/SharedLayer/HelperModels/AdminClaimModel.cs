using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.HelperModels
{
    public class AdminClaimModel
    {   
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public string Date { get; set; }
        public string Currency { get; set; }
        public string ReceiptPhotoFileName { get; set; }
        public string ClaimPhase { get; set; } 
        public string isApproved { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedValue { get; set; }
        public string InternalNotes { get; set; }

    }
}
