public class Token{
    public int id { get; private set; }
    public Guid externalId { get; private set; }
    public string email { get; private set; }
    public string refreshToken { get; private set; }
    public DateTime createdAt { get; private set; }
    public DateTime updatedAt { get; private set; }
    public Token(){
        externalId = Guid.NewGuid();
        createdAt = DateTime.UtcNow;
        updatedAt = DateTime.UtcNow;
    }
}