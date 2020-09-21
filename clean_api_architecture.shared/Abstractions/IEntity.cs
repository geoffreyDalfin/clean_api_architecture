namespace clean_api_architecture.shared.Abstractions
{
    public interface IEntity
    {
        string Id { get; set; }
        int Version { get; set; }
    }
}
