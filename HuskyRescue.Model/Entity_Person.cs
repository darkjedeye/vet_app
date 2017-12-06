
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
    
public partial class Entity_Person
{

    public Entity_Person()
    {

        this.ApplicantOwnedAnimals = new HashSet<ApplicantOwnedAnimal>();

        this.Entity_DonationItems = new HashSet<Entity_DonationItems>();

        this.Entity_File = new HashSet<Entity_File>();

        this.Event_Attendee = new HashSet<Event_Attendee>();

        this.Event_Sponsor = new HashSet<Event_Sponsor>();

        this.Enum_Skills = new HashSet<Enum_Skills>();

        this.Entity_PersonProfile = new HashSet<Entity_PersonProfile>();

        this.Applicants = new HashSet<Applicant>();

        this.Entity_OrganisationContacts = new HashSet<Entity_OrganisationContacts>();

    }


    public System.Guid ID { get; set; }

    public System.Guid BaseID { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Gender { get; set; }

    public string LicenseNumber { get; set; }



    public virtual ICollection<ApplicantOwnedAnimal> ApplicantOwnedAnimals { get; set; }

    public virtual Entity_Base Entity_Base { get; set; }

    public virtual ICollection<Entity_DonationItems> Entity_DonationItems { get; set; }

    public virtual ICollection<Entity_File> Entity_File { get; set; }

    public virtual Enum_Gender Enum_Gender { get; set; }

    public virtual ICollection<Event_Attendee> Event_Attendee { get; set; }

    public virtual ICollection<Event_Sponsor> Event_Sponsor { get; set; }

    public virtual ICollection<Enum_Skills> Enum_Skills { get; set; }

    public virtual ICollection<Entity_PersonProfile> Entity_PersonProfile { get; set; }

    public virtual ICollection<Applicant> Applicants { get; set; }

    public virtual ICollection<Entity_OrganisationContacts> Entity_OrganisationContacts { get; set; }

}

}
