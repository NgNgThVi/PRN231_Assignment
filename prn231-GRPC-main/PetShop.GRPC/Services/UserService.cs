using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using PetShop.BusinessObject.Models;
using PetShop.Repositories.Implements;
using PetShop.Repositories.Interfaces;
using PetShop.Services.Enums;

namespace PetShop.GRPC.Services
{
    public class UserService : UserServices.UserServicesBase
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public override Task<UserResponse> CreateUser(CreateUserRequest request, ServerCallContext context)
        {
            if (request == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Error request"));
            }
            var userItems = new User
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                Email = request.Email,
                Password = request.Password,
                Role = request.Role,    
                Status = request.Status,
            };
            _userRepository.Create(userItems);
            return Task.FromResult(new UserResponse
            {
                Id = userItems.Id.ToString(),
                Status = userItems.Status,
                Role = userItems.Role,
                Username = userItems.Username,
                Email = userItems.Email,
                Password = userItems.Password,
            });
        }

        public override Task<GetAllUserReponse> GetAllUsers(GetAllUserRequest request, ServerCallContext context)
        {
            if (request == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Error request"));
            }
            var response = new GetAllUserReponse();
            var users = _userRepository.Get().Where(x => x.Status == UserStatus.Activate.ToString());
            foreach (var user in users)
            {
                response.User.Add(new UserResponse
                {
                    Id = user.Id.ToString(),
                    Status = user.Status,
                    Role = user.Role,
                    Username = user.Username,
                    Email = user.Email,
                    Password = user.Password,
                });
            }
            return Task.FromResult(response);
        }

        public override Task<UserResponse> UpdateUser(UpdateUserRequest request, ServerCallContext context)
        {
            if (request == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Error request"));
            }
            var user = _userRepository.Get(request.Id);
            if (user == null)
            {
                throw new Exception("Cannot find this user");
            }
            else
            {
                user.Username = request.Username;
                user.Email = request.Email;
                user.Password = request.Password;
                user.Status = request.Status;
                user.Role = request.Role;
            }
            _userRepository.Update(user);
            return Task.FromResult(new UserResponse
            {
                Id = user.Id.ToString()
            });
        }

        public override Task<UserResponse> DeleteUser(DeleteUserRequest request, ServerCallContext context)
        {
            if (request == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Error request"));
            }
            var user = _userRepository.Get(request.Id);
            if (user == null)
            {
                throw new Exception("Cannot find this user");
            }
            else
            {
                _userRepository.Delete(user);
            }
            return base.DeleteUser(request, context);
        }
    }
}
