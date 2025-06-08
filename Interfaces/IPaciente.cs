using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMAUI.Interfaces
{
    public interface IPaciente
    {
        public Task<List<PacienteModel>> GetAll();
        public Task<PacienteModel> GetById(int id);
        public Task<int> InsertPaciente(PacienteModel paciente);
        public Task<int> DeletePaciente(PacienteModel paciente);
        public Task<int> UpdatePaciente(PacienteModel paciente);
    }
}
