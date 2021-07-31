using CodeCamp.Conference.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Contracts.Persistence
{
    public interface ICampRepository:IAsyncRepository<Camp>
    {
        Task<Camp[]> GetAllCampsAsync();
        Task<Camp> GetCampAsync(string moniker);
        Task<Camp[]> GetAllCampsByEventDate(DateTime dateTime);
        Task<bool> CheckIfMonikerExist(string moniker);
       
    }
}
