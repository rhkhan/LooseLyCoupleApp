using LooselyCouple.Data.DbOperationInfrastructure;
using LooselyCouple.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooselyCouple.Data.Repositories
{
    public class AppointmentRepository:RepositoryBase<Appointment>,IAppointmentRepository
    {
        public AppointmentRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }

        public Appointment GetAppointmentFromId(int id)
        {
            var app = this.dataContext.appointments.Where(a => a.Id == id).FirstOrDefault();
            return app;
        }
    }

    public interface IAppointmentRepository:IRepository<Appointment>
    {
        Appointment GetAppointmentFromId(int id);
    }
}
