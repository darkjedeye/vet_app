
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
    
public partial class Entity_StoreOrder
{

    public Entity_StoreOrder()
    {

        this.Entity_StoreOrderDetail = new HashSet<Entity_StoreOrderDetail>();

        this.Entity_StorePayment = new HashSet<Entity_StorePayment>();

        this.Entity_StoreShipment = new HashSet<Entity_StoreShipment>();

    }


    public System.Guid Id { get; set; }

    public string UserName { get; set; }

    public int TotalProducts { get; set; }

    public decimal TotalDue { get; set; }

    public System.DateTime CreatedOn { get; set; }

    public System.DateTime UpdatedOn { get; set; }

    public Nullable<System.DateTime> CompletedOn { get; set; }

    public string Status { get; set; }

    public string ShippingStatus { get; set; }

    public Nullable<System.Guid> PersonBaseId { get; set; }

    public Nullable<System.Guid> BillingAddressId { get; set; }

    public Nullable<System.Guid> ShippingAddressId { get; set; }

    public string SpecialInstructions { get; set; }



    public virtual Entity_Addresses Entity_Addresses { get; set; }

    public virtual Entity_Addresses Entity_Addresses1 { get; set; }

    public virtual Entity_Base Entity_Base { get; set; }

    public virtual ICollection<Entity_StoreOrderDetail> Entity_StoreOrderDetail { get; set; }

    public virtual ICollection<Entity_StorePayment> Entity_StorePayment { get; set; }

    public virtual ICollection<Entity_StoreShipment> Entity_StoreShipment { get; set; }

}

}