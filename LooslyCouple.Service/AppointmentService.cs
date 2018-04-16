using LooselyCouple.Data.DbOperationInfrastructure;
using LooselyCouple.Data.Repositories;
using LooselyCouple.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooslyCouple.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository appRepo;
        private readonly IUnitOperation unitOperation;

        public AppointmentService(AppointmentRepository repo,IUnitOperation unitOp)
        {
            appRepo = repo;
            unitOperation = unitOp;
        }

        public void saveAppointment(Appointment appoint)
        {
            appRepo.add(appoint);
            unitOperation.commit();
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            var appoints = appRepo.GetAll();
            return appoints;
        }

        public Appointment GetAppointById(int id)
        {
            var app = appRepo.GetAppointmentFromId(id);
            return app;
        }

        public void UpdateAppointment(Appointment appo)
        {
            appRepo.update(appo);
            unitOperation.commit();
        }
    }

    public interface IAppointmentService
    {
        void saveAppointment(Appointment appoint);
        IEnumerable<Appointment> GetAppointments();
        Appointment GetAppointById(int id);
        void UpdateAppointment(Appointment appo);
    }
}
