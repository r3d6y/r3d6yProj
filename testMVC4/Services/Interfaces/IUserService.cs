using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testMVC4.Models;

namespace testMVC4.Services.Interfaces
{
    public interface IUserService : IDisposable
    {
        User Insert(UserModel model);
        bool Delete(int id);
        IEnumerable<User> List();
        User GetById(int id);
        User GetByEmail(string email);
        void Update(UserModel model);
        PacientInfo AddPacientInfo(PacientModel model);
        IList<CategoryLevelModel> GetCategories();
        IList<UnitModel> GetUnits();
        IList<FullDoctorInfoModel> GetDoctorsList();
    }
}
