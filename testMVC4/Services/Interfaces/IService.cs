using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testMVC4.Services.Interfaces
{
    public interface IService
    {
        IUserService UserService { get; }
        INewsService NewsService { get; }
        IReceptionService ReceptionService { get; }
    }
}
