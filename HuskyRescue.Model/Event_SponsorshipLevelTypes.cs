
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
    
public partial class Event_SponsorshipLevelTypes
{

    public Event_SponsorshipLevelTypes()
    {

        this.Event_SponsorshipLevel = new HashSet<Event_SponsorshipLevel>();

    }


    public int ID { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public Nullable<decimal> SponsorAmount { get; set; }



    public virtual ICollection<Event_SponsorshipLevel> Event_SponsorshipLevel { get; set; }

}

}
