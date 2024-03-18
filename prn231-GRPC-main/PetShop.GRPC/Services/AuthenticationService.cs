using Grpc.Core;
using PetShop.BusinessObject.Models;
using PetShop.Repositories.Interfaces;
using PetShop.Services.Utils;

namespace PetShop.GRPC.Services
{
    public class AuthenticationService : Authentication.AuthenticationBase
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public override Task<AuthenticationResponse> Authenticate(AuthenticationRequest request, ServerCallContext context)
        {
            User user = _userRepository.Get().FirstOrDefault(x => x.Username == request.Username && x.Password == request.Password);

            if (user != null)
            {
                string accessToken = JwtUtil.GenerateJwtToken(user);

                return Task.FromResult(new AuthenticationResponse
                {
                    AccessToken = accessToken,
                    ExpiresIn = 3600
                });
            }
            else
            {
                throw new RpcException(new Status(StatusCode.Unauthenticated, "Invalid username or password"));
            }
        }
    }
}