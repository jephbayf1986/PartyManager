using PartyManager.Application.Shared.CQRS;

namespace PartyManager.Application.Main.PartyGuests.Commands
{
    public class UpdateVipStatus : ICommand
    {
        public int Id { get; set; }

        public bool IsVip { get; set; }
    }
}