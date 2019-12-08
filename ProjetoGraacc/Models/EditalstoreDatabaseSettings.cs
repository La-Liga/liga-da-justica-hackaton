namespace ProjetoGraacc.Models
{
    public class EditalstoreDatabaseSettings : IEditalstoreDatabaseSettings
    {
        public string EditaisCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IEditalstoreDatabaseSettings
    {
        string EditaisCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}