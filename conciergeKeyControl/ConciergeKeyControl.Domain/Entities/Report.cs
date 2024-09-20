public class Report
{
    public int Id { get; private set; }
    public Guid ExternalId { get; private set; }
    public int IdUser { get; private set; }
    public int IdKey { get; private set; }
    public Status Status { get; private set; }
    public DateTime WithdrawalDate { get; private set; }
    public DateTime? ReturnDate { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public Key Key { get; private set; }
    public User User { get; private set; }
    public Report(){
        ExternalId = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        Status = Status.Available;
    }
}