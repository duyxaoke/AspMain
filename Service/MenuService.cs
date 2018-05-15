using System.Collections.Generic;
using Core.Data;
using Service.Models;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;
using Service.CacheService;
using System.Linq;
using Shared.Models;

namespace Service
{
    public interface IMenuServices
    {
        Menu GetMenu(int id);
        IEnumerable<MenuViewModel> GetAllMenu();
        void AddMenu(Menu model);
        void UpdateMenu(Menu model);
        void DeleteMenu(int id);
        void Save();
        void Dispose();

    }
    public class MenuServices : IMenuServices
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        public Menu GetMenu(int id)
        {
            return _unitOfWork.MenuRepository.GetById(id);
        }
        public IEnumerable<MenuViewModel> GetAllMenu()
        {
            return _unitOfWork.MenuViewRepository.ExecWithStoreProcedure("SELECT * FROM MenuView").ToList();
        }
        public void AddMenu(Menu model)
        {
            _unitOfWork.MenuRepository.Update(model);

        }
        public void UpdateMenu(Menu model)
        {
            _unitOfWork.MenuRepository.Update(model);

        }
        public void DeleteMenu(int id)
        {
            _unitOfWork.MenuRepository.Delete(id);

        }
        
        public void Save()
        {
            _unitOfWork.Save();
        }
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
