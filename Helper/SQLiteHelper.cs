using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoMAUI.Servicios;

namespace ProyectoMAUI.Helper
{
    public class SQLiteHelper<T> : SQLiteBase where T : ModeloBase, new()
    {
        public List<T> GetAllData()
            => _connection.Table<T>().ToList();

        public int Add(T row)
        {
            _connection.Insert(row);
            return row.Id;
        }

        public int Update(T row)
            => _connection.Update(row);

        public int Delete(T row)
            => _connection.Delete(row);

        public T Get(int ID)
            => _connection.Table<T>().Where(w => w.Id == ID).FirstOrDefault();
    }

    public class SQLiteBase
    {
        private string _rutaDB;
        public SQLiteConnection _connection;

        public SQLiteBase()
        {
            _rutaDB = FileAccessHelper.GetPathFile("alumnos.db3");
            if (_connection != null) return;
            _connection = new SQLiteConnection(_rutaDB);
            _connection.CreateTable<PacienteModel>();
        }
    }
}
