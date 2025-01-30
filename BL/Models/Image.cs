using System;
using System.Collections.Generic;

namespace BL.Models;

public partial class Image
{
    public int Id { get; set; }

    public string Path { get; set; } = null!;

    public virtual ICollection<Group> Groups { get; } = new List<Group>();

    public virtual ICollection<Message> Messages { get; } = new List<Message>();

    public virtual ICollection<User> Users { get; } = new List<User>();
}
