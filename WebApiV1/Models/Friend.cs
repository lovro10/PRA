using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Friend
{
    public int Id { get; set; }

    public int SenderId { get; set; }

    public int RecieverId { get; set; }

    public DateTime DateSent { get; set; }

    public bool IsAccepted { get; set; }

    public virtual User Reciever { get; set; } = null!;

    public virtual User Sender { get; set; } = null!;
}
