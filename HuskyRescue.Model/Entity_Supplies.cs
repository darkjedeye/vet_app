
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
    
public partial class Entity_Supplies
{

    public Entity_Supplies()
    {

        this.Entity_SupplyPlacement = new HashSet<Entity_SupplyPlacement>();

    }


    public System.Guid ID { get; set; }

    public int SupplyType { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public System.DateTime LastUpdateTimestamp { get; set; }

    public string Notes { get; set; }



    public virtual ICollection<Entity_SupplyPlacement> Entity_SupplyPlacement { get; set; }

    public virtual Entity_SupplyType Entity_SupplyType { get; set; }

}

}
