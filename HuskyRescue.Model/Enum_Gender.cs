
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
    
public partial class Enum_Gender
{

    public Enum_Gender()
    {

        this.Entity_Person = new HashSet<Entity_Person>();

    }


    public string ID { get; set; }

    public string Value { get; set; }



    public virtual ICollection<Entity_Person> Entity_Person { get; set; }

}

}