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
            if(user != null)
            {
                pacientRepository.Insert(ref pacientToCreate);
                user.PacientInfo = (int?)pacientToCreate.Id;
                userRepository.Update(user);
            }
            return pacientToCreate;
        }

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
            if(model.Id != null && model.Id != 0)
                userToCreate.Id = (long)model.Id;

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

        public void Dispose()
        {

        }
    }
}