using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testMVC4.Models;
using testMVC4.Repositories;
using testMVC4.Services.Interfaces;

namespace testMVC4.Services
{
    public class UserService : IUserService
    {
        private readonly BaseRepository<User> userRepository;
        private readonly BaseRepository<PacientInfo> pacientRepository;
        private readonly BaseRepository<DoctorInfo> doctorRepository;
        private readonly BaseRepository<Location> locationRepository;
        private readonly BaseRepository<CategoryLevel> categoryRepository;
        private readonly BaseRepository<HospitalUnit> unitRepository;


        public UserService()
        {
            userRepository = new BaseRepository<User>();
            pacientRepository = new BaseRepository<PacientInfo>();
            doctorRepository = new BaseRepository<DoctorInfo>();
            locationRepository = new BaseRepository<Location>();
            categoryRepository = new BaseRepository<CategoryLevel>();
            unitRepository = new BaseRepository<HospitalUnit>();
        }

        public User Insert(UserModel model)
        {
            User userToCreate = CopyUserFromModel(model);
            //userRepository.InsertOrUpdate(userToCreate, userToCreate.Id);
            userRepository.Insert(ref userToCreate);
            return userToCreate;
        }

        public bool Delete(int id)
        {
            var user = userRepository.FirstOrDefault(u => u.Id == id);
            if (user != null)
                return userRepository.Delete(user);
            else
                return false;
        }

        public IEnumerable<User> List()
        {
            return userRepository.ToList();
        }

        public User GetById(int id)
        {
            return userRepository.FirstOrDefault(u => u.Id == id);
        }

        public User GetByEmail(string email)
        {
            return userRepository.FirstOrDefault(u => u.Email == email);
        }

        public void Update(UserModel model)
        {
            User userToUpdate = CopyUserFromModel(model);
            userRepository.Update(userToUpdate);
        }

        public PacientInfo AddPacientInfo(PacientModel model)
        {
            PacientInfo pacientToCreate = CopyPacientFromModel(model);
            var user = userRepository.FirstOrDefault(u => u.Id == model.UserId);
            if (user != null)
            {
                pacientRepository.Insert(ref pacientToCreate);
                user.PacientInfo = (int?)pacientToCreate.Id;
                userRepository.Update(user);
            }
            return pacientToCreate;
        }

        public DoctorInfo AddDoctorInfo(DoctorModel model)
        {
            DoctorInfo doctorToCreate = CopyDoctorFromModel(model);
            try
            {
                var user = userRepository.FirstOrDefault(u => u.Id == model.UserId);
                if (user != null)
                {
                    doctorRepository.Insert(ref doctorToCreate);
                    user.DoctorInfo = (int?)doctorToCreate.Id;
                    user.is_doctor = true;
                    userRepository.Update(user);
                }
            }
            catch(Exception ex)
            {

            }
            
            return doctorToCreate;
        }

        public IList<CategoryLevelModel> GetCategories()
        {
            List<CategoryLevelModel> categoryList = new List<CategoryLevelModel>();

            var allCat = categoryRepository.ToList();
            foreach (var c in allCat)
                categoryList.Add(new CategoryLevelModel(c));
            return categoryList;
        }

        public IList<UnitModel> GetUnits()
        {
            List<UnitModel> unitList = new List<UnitModel>();
            var allUnit = unitRepository.ToList();
            foreach (var u in allUnit)
                unitList.Add(new UnitModel(u));
            return unitList;
        }

        public IList<FullDoctorInfoModel> GetDoctorsList()
        {
            List<FullDoctorInfoModel> doctorList = new List<FullDoctorInfoModel>();
            var allDoctors = doctorRepository.ToList();
            foreach (var d in allDoctors)
            {
                DoctorModel doctor = new DoctorModel(d);
                UserModel user = new UserModel(userRepository.FirstOrDefault(x => x.DoctorInfo == d.Id));
                doctorList.Add(new FullDoctorInfoModel(doctor, user));
            }
            return doctorList.Where(x => x.UserModel.IsDoctor).ToList();
        }

        public void SetDoctor(UserModel model)
        {
            var user = userRepository.FirstOrDefault(x => x.Id == model.Id);
            user.is_doctor = model.IsDoctor;
            userRepository.Update(user);
        }

        public DoctorInfo GetDoctorById(int id)
        {
            return doctorRepository.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateDoctorInfo(DoctorModel model)
        {
            var doctorToUpdate = doctorRepository.FirstOrDefault(x => x.Id == model.Id);
            doctorToUpdate.AboutDoc = model.AboutDoc;
            doctorToUpdate.CvalId = model.CvalId;
            if(model.LocationId > 0)
                doctorToUpdate.LocationId = model.LocationId = model.LocationId;// > 0 ? model.LocationId : doctorToUpdate.LocationId;
            doctorToUpdate.Photo = model.Photo;
            doctorToUpdate.UnitId = model.UnitId;
            doctorToUpdate.WorkPhone = model.WorkPhone;

            doctorRepository.Update(doctorToUpdate);
        }

        public void UpdateUserProfil(UserModel model)
        {
            var userProfil = userRepository.FirstOrDefault(x => x.Id == model.Id);
            userProfil.Address = model.Address;
            userProfil.Birthday = model.Birthday;
            userProfil.LastName = model.LastName;
            userProfil.SecondName = model.SecondName;
            userProfil.UserName = model.UserName;
            userRepository.Update(userProfil);
        }

        public PacientInfo GetPacientInfoById(int id)
        {
            return pacientRepository.FirstOrDefault(x => x.Id == id);
        }

        public void UpdatePacientProfil(PacientModel model)
        {
            var pacientInfo = pacientRepository.FirstOrDefault(x => x.Id == model.Id);
            pacientInfo.Phone = model.Phone;
            pacientInfo.SocialNumber = model.SocialNumber;
            pacientInfo.CardNumber = model.CardNumber;

            pacientRepository.Update(pacientInfo);
        }

        public int GetUserIdByDocId(int id)
        {
            return (int)userRepository.FirstOrDefault(x => x.DoctorInfo == id).Id;
        }

        #region private methods
        private User CopyUserFromModel(UserModel model)
        {
            User userToCreate = new User();
            userToCreate.UserName = model.UserName;
            userToCreate.LastName = model.LastName;
            userToCreate.SecondName = model.SecondName;
            userToCreate.Password = model.Password;
            userToCreate.PasswordSalt = model.PasswordSalt;
            userToCreate.Birthday = model.Birthday;
            userToCreate.Address = model.Address;
            userToCreate.DoctorInfo = model.DoctorInfo;
            userToCreate.PacientInfo = model.PacientInfo;
            userToCreate.Email = model.Email;
            if (model.Id != null && model.Id != 0)
                userToCreate.Id = (long)model.Id;
            userToCreate.is_doctor = model.IsDoctor;
            userToCreate.is_admin = model.IsAdmin;

            return userToCreate;
        }

        private PacientInfo CopyPacientFromModel(PacientModel model)
        {
            PacientInfo pacientToCreate = new PacientInfo();
            pacientToCreate.CardNumber = model.CardNumber;
            pacientToCreate.SocialNumber = model.SocialNumber;
            pacientToCreate.Phone = model.Phone;
            if (model.Id != null && model.Id != 0)
                pacientToCreate.Id = (long)model.Id;

            return pacientToCreate;
        }

        private DoctorInfo CopyDoctorFromModel(DoctorModel model)
        {
            DoctorInfo doctorToCreate = new DoctorInfo();
            doctorToCreate.CvalId = model.CvalId;
            doctorToCreate.UnitId = model.UnitId;
            doctorToCreate.Id = model.Id;
            doctorToCreate.WorkPhone = model.WorkPhone;
            doctorToCreate.Photo = model.Photo;
            doctorToCreate.SpecificName = model.SpecificName;
            doctorToCreate.AboutDoc = model.AboutDoc;
            return doctorToCreate;
        }
        #endregion

        public void Dispose()
        {

        }
    }
}