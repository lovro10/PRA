using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Message
{
    public int Id { get; set; }

    public DateTime DateCreated { get; set; }

    public string Content { get; set; } = null!;

    public DateTime? DateRead { get; set; }

    public int UserId { get; set; }

    public int GroupId { get; set; }

    public int? ImageId { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual Image? Image { get; set; }

    public virtual User User { get; set; } = null!;
}
