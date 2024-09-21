public class Token{
    public int Id { get; private set; }
    public Guid ExternalId { get; private set; }
    public string Email { get; private set; }
    public string RefreshToken { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public Token(){
        ExternalId = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
}