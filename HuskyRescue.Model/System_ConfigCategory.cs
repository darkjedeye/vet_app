
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
    
public partial class System_ConfigCategory
{

    public System_ConfigCategory()
    {

        this.System_Config = new HashSet<System_Config>();

    }


    public string Name { get; set; }

    public string Description { get; set; }



    public virtual ICollection<System_Config> System_Config { get; set; }

}

}