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
    
    public partial class Goal
    {
        public int GoalID { get; set; }
        public int TargetID { get; set; }
        public int TargetBMI { get; set; }
        public int Target { get; set; }
        public int Weight { get; set; }
        public Nullable<System.DateTime> CreatedData { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedData { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
