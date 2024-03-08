namespace NguyenNgocThaiVi_SE160956_Assignment.Service.Accounts
{
    public class AccountDTO
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime? Birthday { get; set; }
    }
    public class  LoginModel
    {
        public string Token { get; set; } = null!;
    }
    public class AccountLoginResponse
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string RoleName { get; set; } = null!;
        public DateTime? Birthday { get; set; }
        public Guid ApplicationUserId {  get; set; }
    }
    public class AccountCustomerDTO : AccountDTO
    {
        public Guid AccountId { get; set; }
        public Guid CustomerId { get; set; }
    }
    public class AccountAdminDTO : AccountDTO
    {
        public Guid AccountId { get; set; }
        public Guid AdminId { get; set;}
    }
}
