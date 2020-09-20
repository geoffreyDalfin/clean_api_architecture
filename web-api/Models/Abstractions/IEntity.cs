namespace web_api.Models.Base
{
    public interface IEntity
    {
        string Id { get; set; }
        int Version { get; set; }
    }
}
