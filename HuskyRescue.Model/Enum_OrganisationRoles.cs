
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
    
public partial class Enum_OrganisationRoles
{

    public Enum_OrganisationRoles()
    {

        this.Entity_OrganisationContacts = new HashSet<Entity_OrganisationContacts>();

    }


    public int ID { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }



    public virtual ICollection<Entity_OrganisationContacts> Entity_OrganisationContacts { get; set; }

}

}
