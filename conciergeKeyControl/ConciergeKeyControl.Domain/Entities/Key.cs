public class Key{
    public int Id { get; private set; }
    public Guid ExternalId { get; private set; }
    public int IdRoom { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public Room Room { get; private set; }
    public List<Report> reports { get; private set; }
    public Key(){
        ExternalId = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
}