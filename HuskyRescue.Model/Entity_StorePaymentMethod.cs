
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
    
public partial class Entity_StorePaymentMethod
{

    public Entity_StorePaymentMethod()
    {

        this.Entity_StorePayment = new HashSet<Entity_StorePayment>();

    }


    public System.Guid Id { get; set; }

    public bool IsActive { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public System.DateTime CreatedOn { get; set; }

    public string CreatedByUser { get; set; }

    public System.DateTime UpdatedOn { get; set; }

    public string UpdatedByUser { get; set; }

    public Nullable<System.DateTime> DeletedOn { get; set; }

    public string DeletedByUser { get; set; }



    public virtual ICollection<Entity_StorePayment> Entity_StorePayment { get; set; }

}

}
