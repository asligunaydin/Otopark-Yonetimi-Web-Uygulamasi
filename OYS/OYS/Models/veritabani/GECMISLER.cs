//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OYS.Models.veritabani
{
    using System;
    using System.Collections.Generic;
    
    public partial class GECMISLER
    {
        public int gecmisID { get; set; }
        public Nullable<int> uyeID { get; set; }
        public Nullable<int> otoparkID { get; set; }
        public Nullable<int> ucret { get; set; }
        public Nullable<System.TimeSpan> girisSaati { get; set; }
        public Nullable<System.TimeSpan> cikisSaati { get; set; }
        public string otoparkAdi { get; set; }
        public string otoparkAdres { get; set; }
    }
}
