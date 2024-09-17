public class Room{
    public int id { get; private set; }
    public Guid externalId { get; private set; }
    public string name { get; private set; }
    public DateTime createdAt { get; private set; }
    public DateTime updatedAt { get; private set; }
    public List<Key> keys { get; private set; }
    public Room(){
        externalId = Guid.NewGuid();
        createdAt = DateTime.UtcNow;
        updatedAt = DateTime.UtcNow;
    }
}