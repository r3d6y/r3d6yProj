using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testMVC4.Models
{
    public class ReceptionModel
    {
        public ReceptionModel()
        {

        }

        public ReceptionModel(ReceptionHour model)
        {
            Id = model.Id;
            Week = model.Week;
            Day = model.Day;
            Time = model.Time;
            Duration = model.Duration;
            DoctorId = (int)model.DoctorId;
        }

        public long Id { get; set; }
        public int Week { get; set; }
        public int Day { get; set; }
        public TimeSpan Time { get; set; }
        public TimeSpan Duration { get; set; }
        public int DoctorId { get; set; }
        public string DayName
        {
            get
            {
                switch(this.Day)
                {
                    case 1:
                        return "Понедельник";
                    case 2:
                        return "Вторник";
                    case 3:
                        return "Среда";
                    case 4:
                        return "Четверг";
                    case 5:
                        return "Пятница";
                    case 6:
                        return "Суббота";
                    case 7:
                        return "Воскресенье";
                    default:
                        return "Unknow";
                }
            }
            set { }
        }
    }
}