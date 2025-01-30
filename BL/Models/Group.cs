using System;
using System.Collections.Generic;

namespace BL.Models;

public partial class Group
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public int? ImageId { get; set; }

    public virtual ICollection<GroupUser> GroupUsers { get; } = new List<GroupUser>();

    public virtual Image? Image { get; set; }

    public virtual ICollection<Message> Messages { get; } = new List<Message>();
}
