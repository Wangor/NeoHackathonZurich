using System;
using System.Collections.Generic;
using System.Text;
using WebPlatform.DataAccess.Repositories;

namespace WebPlatform.DataAccess.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string GetUserPublicAddress(Guid userId)
        {
            var user = _userRepository.GetUserById(userId);
            return user != null ? user.UserNeoAddress : string.Empty;
        }

        public string GetUserPrivateKey(Guid userId)
        {
            var user = _userRepository.GetUserById(userId);
            return user != null ? user.UserPrivateKey : string.Empty;
        }

        public string GetUserPublicAddressByEMail(string receiverEMail)
        {
            var user = _userRepository.GetUserByEMail(receiverEMail);

            return user != null ? user.UserNeoAddress : string.Empty;
        }
    }
}
