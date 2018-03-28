using MongoDB.Bson;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartHome.DAL.UnitOfWork;

namespace SmartHome.DAL
{
    public class ScheduleMapper : IScheduleMapper
    {
        private UnitOfWork<Schedule> Uow;

        public ScheduleMapper() 
        {
            // initialise Uow    
        }

        public void Create(Schedule obj)
        {
            // create schedule object query
            // Uow.RegisterQuery(query)
            throw new NotImplementedException();
        }

        public Schedule Delete(ObjectId id)
        {
            // delete schedule object query
            // Uow.RegisterQuery(query)
            throw new NotImplementedException();
        }

        public void Save()
        {
            // Uow.SaveChanges()
            throw new NotImplementedException();
        }

        public IEnumerable<Schedule> SelectAll()
        {
            // make query for selecting all schedule
            // Uow.ExecuteSelection(query)
            // return result
            throw new NotImplementedException();
        }

        public Schedule SelectByDevice(ObjectId deviceId)
        {
            // make query for selecting schedule by deviceId
            // Uow.ExecuteSelection(query)
            // return result
            throw new NotImplementedException();
        }

        public Schedule SelectById(ObjectId id)
        {
            // make query for selecting schedule by _id
            // Uow.ExecuteSelection(query)
            // return result
            throw new NotImplementedException();
        }

        public void Update(Schedule obj)
        {
            // update schedule object query
            // Uow.RegisterQuery(query)
            throw new NotImplementedException();
        }
    }
}
