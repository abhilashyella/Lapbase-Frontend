//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lapbase_Application
{
    using System;
    using System.Collections.Generic;
    
    public partial class Report
    {
        public int ReportID { get; set; }
        public int PatientID { get; set; }
        public int Weight { get; set; }
        public int Ideal { get; set; }
        public Nullable<System.DateTime> CreatedData { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedData { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}