using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testMVC4.Models;
using testMVC4.Repositories;
using testMVC4.Services.Interfaces;

namespace testMVC4.Services
{
    public class ReceptionService : IReceptionService
    {
        BaseRepository<ReceptionHour> receptionRepository;
        BaseRepository<DoctorInfo> doctorRepository;
        BaseRepository<User> userRepository;

        public ReceptionService()
        {
            receptionRepository = new BaseRepository<ReceptionHour>();
            doctorRepository = new BaseRepository<DoctorInfo>();
            userRepository = new BaseRepository<User>();
        }

        public ReceptionHour AddReceptionHour(ReceptionModel model)
        {
            var hourToCreate = CopyHourFromModel(model);
            receptionRepository.Insert(ref hourToCreate);
            return hourToCreate;
        }

        public void AddReceptionHoursForUser(int id)
        {
            var user = userRepository.FirstOrDefault(x => x.Id == id);
            for(int i = 1; i <=7; i++)
            {
                ReceptionHour hourToCreate = new ReceptionHour
                {
                    Week = 1,
                    Day = i,
                    Time = new TimeSpan(0, 0, 0),
                    Duration = new TimeSpan(0, 0, 0),
                    DoctorId = user.DoctorInfo
                };

                receptionRepository.Insert(ref hourToCreate);
            }
        }

        public void UpdateReceptionsForUser(List<ReceptionModel> model)
        {
            foreach(var m in model)
            {
                var hourToUpdate = receptionRepository.FirstOrDefault(x => x.Id == m.Id);
                hourToUpdate.Day = m.Day;
                hourToUpdate.Time = m.Time;
                hourToUpdate.Duration = m.Duration;
                receptionRepository.Update(hourToUpdate);
            }
        }

        public void EditReceptionHour(ReceptionModel model)
        {
            var hourToUpdate = receptionRepository.FirstOrDefault(x => x.Id == model.Id);
            hourToUpdate.Day = model.Day;
            hourToUpdate.Week = model.Week;
            hourToUpdate.Time = model.Time;
            hourToUpdate.Duration = model.Duration;

            receptionRepository.Update(hourToUpdate);
        }

        public ReceptionHour GetReceptionById(int id)
        {
            return receptionRepository.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ReceptionHour> GetReceptionByUserId(int id)
        {
            var user = userRepository.FirstOrDefault(x => x.Id == id);
            return receptionRepository.ToList().Where(x => x.DoctorId == user.DoctorInfo); //(x => x.DoctorId == user.DoctorInfo);
        }


        private ReceptionHour CopyHourFromModel(ReceptionModel model)
        {
            ReceptionHour hourToCreate = new ReceptionHour();
            hourToCreate.Id = model.Id;
            hourToCreate.Day = model.Day;
            hourToCreate.DoctorId = model.DoctorId;
            hourToCreate.Duration = model.Duration;
            hourToCreate.Time = model.Time;
            hourToCreate.Week = model.Week;

            return hourToCreate;
        }
    }
}