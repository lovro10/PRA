using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Image
{
    public int Id { get; set; }

    public string Path { get; set; } = null!;

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
