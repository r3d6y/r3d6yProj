using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testMVC4.Models;

namespace testMVC4.Services.Interfaces
{
    public interface IReceptionService
    {
        ReceptionHour AddReceptionHour(ReceptionModel model);
        void AddReceptionHoursForUser(int id);
        void EditReceptionHour(ReceptionModel model);
        ReceptionHour GetReceptionById(int id);
        IEnumerable<ReceptionHour> GetReceptionByUserId(int id);
        void UpdateReceptionsForUser(List<ReceptionModel> model);
    }
}
