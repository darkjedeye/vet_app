
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
    
public partial class ApplicantVeterinarian
{

    public ApplicantVeterinarian()
    {

        this.Applicants = new HashSet<Applicant>();

    }


    public System.Guid ID { get; set; }

    public string NameOffice { get; set; }

    public string NameDr { get; set; }

    public string PhoneNumber { get; set; }



    public virtual ICollection<Applicant> Applicants { get; set; }

}

}
