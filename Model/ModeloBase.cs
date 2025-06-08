namespace ProyectoMAUI.Model
{
    public abstract class ModeloBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
