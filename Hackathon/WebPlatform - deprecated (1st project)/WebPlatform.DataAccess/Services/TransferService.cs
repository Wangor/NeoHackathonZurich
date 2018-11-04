using System;
using System.Collections.Generic;
using System.Text;

namespace WebPlatform.DataAccess.Services
{
    public class TransferService
    {
        private readonly ContractService _contractService;
        private readonly UserService _userService;
        private readonly TicketService _ticketService;

        public TransferService(ContractService contractService, UserService userService, TicketService ticketService)
        {
            _contractService = contractService;
            _userService = userService;
            _ticketService = ticketService;
        }

        public bool Transfer(string ticketId, Guid senderId, string receiverEMail)
        {
            var senderPrivateKey = _userService.GetUserPrivateKey(senderId);
            var receiverAddress = _userService.GetUserPublicAddressByEMail(receiverEMail);

            _contractService.TransferService(ticketId, senderPrivateKey, receiverAddress);

            _ticketService.TransferTicket(ticketId, receiverAddress);

            return true;
        }
    }
}
