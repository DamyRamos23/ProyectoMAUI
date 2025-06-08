using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMAUI.Servicios
{
    public class ServicioPaciente : IPaciente
    {
        private readonly SQLiteHelper<PacienteModel> db;

        public ServicioPaciente() 
            => db = new();
        public Task<int> DeletePaciente(PacienteModel paciente)
            => Task.FromResult(db.Delete(paciente));

        public Task<List<PacienteModel>> GetAll()
            => Task.FromResult(db.GetAllData());

        public Task<PacienteModel> GetById(int id)
            => Task.FromResult(db.Get(id));

        public Task<int> InsertPaciente(PacienteModel paciente)
            => Task.FromResult(db.Add(paciente));

        public Task<int> UpdatePaciente(PacienteModel paciente)
            => Task.FromResult(db.Update(paciente));
    }
}
