public class Key{
    public int id { get; private set; }
    public Guid externalId { get; private set; }
    public int idRoom { get; private set; }
    public DateTime createdAt { get; private set; }
    public DateTime updatedAt { get; private set; }
    public Room room { get; private set; }
    public Key(){
        externalId = Guid.NewGuid();
        createdAt = DateTime.UtcNow;
        updatedAt = DateTime.UtcNow;
    }
}