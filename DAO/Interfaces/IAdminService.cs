using CarConnectApp.Entity;

namespace CarConnectApp.DAO.Interfaces
{
    public interface IAdminService
    {
        void AddAdmin(Admin admin);
        Admin GetAdminById(int id);
        Admin GetAdminByUsername(string username);
        void UpdateAdmin(Admin admin);
        void DeleteAdmin(int id);
    }
}
