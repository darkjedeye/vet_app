
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace HuskyRescue.Model
{

using System;
    using System.Collections.Generic;
    
public partial class Entity_File
{

    public System.Guid ID { get; set; }

    public Nullable<System.Guid> PersonID { get; set; }

    public Nullable<System.Guid> OrgID { get; set; }

    public Nullable<System.Guid> DogID { get; set; }

    public System.DateTimeOffset DateCreated { get; set; }

    public string ContentType { get; set; }

    public string ServerPath { get; set; }



    public virtual Entity_Dog Entity_Dog { get; set; }

    public virtual Entity_Organisation Entity_Organisation { get; set; }

    public virtual Entity_Person Entity_Person { get; set; }

}

}
