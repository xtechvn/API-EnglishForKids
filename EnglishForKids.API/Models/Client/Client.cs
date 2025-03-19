using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EnglishForKids.API.Entities.Models
{
    public class Client
    {
        public long Id { get; set; }                    // bigint Unchecked (nullable not needed for PK)
        public int ClientMapId { get; set; }            // int Checked
        public int SaleMapId { get; set; }             // int Checked
        public int ClientType { get; set; }            // int Checked
        public string ClientName { get; set; }         // nvarchar(256) Checked
        public string Email { get; set; }             // varchar(255) Checked
        public int Gender { get; set; }               // int Checked
        public int? Status { get; set; }              // int Unchecked (nullable)
        public string Note { get; set; }              // nvarchar(400) Checked
        public string Avartar { get; set; }           // varchar(400) Checked (assuming typo in 'Avatar')
        public DateTime? JoinDate { get; set; }       // datetime Unchecked (nullable)
        public bool IsReceiverInfoEmail { get; set; } // bit Checked
        public string Phone { get; set; }             // varchar(50) Checked
        public DateTime Birthday { get; set; }        // datetime Checked
        public DateTime UpdateTime { get; set; }      // datetime Checked
        public string TaxNo { get; set; }             // varchar(50) Checked
        public int AgencyType { get; set; }           // int Checked
        public int PermisionType { get; set; }        // int Checked (assuming typo in 'PermissionType')
        public string BusinessAddress { get; set; }   // nvarchar(200) Checked
        public string ExportBillAddress { get; set; } // nvarchar(200) Checked
        public string ClientCode { get; set; }        // varchar(20) Checked
        public bool IsRegisterAffiliate { get; set; } // bit Checked
        public string ReferralId { get; set; }        // varchar(200) Checked
        public int ParentId { get; set; }             // int Checked
    }
}
