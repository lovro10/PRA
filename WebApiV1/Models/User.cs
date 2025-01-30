using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public DateTime DateJoined { get; set; }

    public string Email { get; set; } = null!;

    public bool EmailConfirmed { get; set; }

    public bool IsAdmin { get; set; }

    public int? ImageId { get; set; }

    public string PwdHash { get; set; } = null!;

    public string PwdSalt { get; set; } = null!;

    public virtual ICollection<Friend> FriendRecievers { get; set; } = new List<Friend>();

    public virtual ICollection<Friend> FriendSenders { get; set; } = new List<Friend>();

    public virtual ICollection<GroupUser> GroupUsers { get; set; } = new List<GroupUser>();

    public virtual Image? Image { get; set; }

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
}
