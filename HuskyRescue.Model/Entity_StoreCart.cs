
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
    
public partial class Entity_StoreCart
{

    public Entity_StoreCart()
    {

        this.Entity_StoreCartItem = new HashSet<Entity_StoreCartItem>();

    }


    public System.Guid Id { get; set; }

    public string UserName { get; set; }

    public System.DateTime CreatedOn { get; set; }

    public System.DateTime UodatedOn { get; set; }



    public virtual ICollection<Entity_StoreCartItem> Entity_StoreCartItem { get; set; }

}

}
