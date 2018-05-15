using System.Collections.Generic;
using Core.Data;
using Service.Models;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;
using Service.CacheService;
using System.Linq;

namespace Service
{
    public interface IConfigServices
    {
        IEnumerable<Config> GetAllConfig();
        Config GetConfig();
        void UpdateConfig(Config model);

        void Save();
        void Dispose();

    }
    public class ConfigServices : IConfigServices
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        public IEnumerable<Config> GetAllConfig()
        {
            return _unitOfWork.ConfigRepository.GetAll();
        }
        public Config GetConfig()
        {
            return _unitOfWork.ConfigRepository.GetById(1);
        }
        public void UpdateConfig(Config model)
        {
            _unitOfWork.ConfigRepository.Update(model);

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
