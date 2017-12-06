
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
    
public partial class Blog_Post
{

    public Blog_Post()
    {

        this.Blog_Comments = new HashSet<Blog_Comments>();

        this.Blog_Tags = new HashSet<Blog_Tags>();

    }


    public System.Guid ID { get; set; }

    public bool IsPublished { get; set; }

    public bool IsCommentEnabled { get; set; }

    public bool IsDeleted { get; set; }

    public System.DateTime DateCreated { get; set; }

    public Nullable<System.DateTime> DateModified { get; set; }

    public System.Guid OriginalAuthor { get; set; }

    public Nullable<System.Guid> LastModifyAuthor { get; set; }

    public string Title { get; set; }

    public string Slug { get; set; }

    public string Description { get; set; }

    public string PostContent { get; set; }



    public virtual ICollection<Blog_Comments> Blog_Comments { get; set; }

    public virtual ICollection<Blog_Tags> Blog_Tags { get; set; }

}

}
