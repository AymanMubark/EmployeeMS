namespace EmployeeMS.Services
{
    public interface IAuthService
    {
        Task<string> Login(string userName, string passsword);
    }
}
