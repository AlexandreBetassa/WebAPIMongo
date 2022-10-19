namespace APIAgendaMongo.Utils
{
    public interface IDatabaseSettings
    {
        string ClientCollectionName { get; set; }
        string AdressCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
