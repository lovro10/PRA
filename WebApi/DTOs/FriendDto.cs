using BL.Models;

namespace WebApi.DTOs
{
    public class FriendDto
    {
        public int Id { get; set; }

        public int SenderId { get; set; }

        public User UserSender { get; set; }

        public int ReceiverId { get; set; }

        public User UserReceiver { get; set; }

        public DateTime DateSent { get; set; }

        public bool IsAccepted { get; set; } = false;
    }
}
