
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
    
public partial class Enum_PetDepositCoverage
{

    public Enum_PetDepositCoverage()
    {

        this.Applicants = new HashSet<Applicant>();

    }


    public int ID { get; set; }

    public string Value { get; set; }



    public virtual ICollection<Applicant> Applicants { get; set; }

}

}
