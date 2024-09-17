public class Report
{
    public int id { get; private set; }
    public Guid externalId { get; private set; }
    public int idUser { get; private set; }
    public int idRoom { get; private set; }
    public Status status { get; private set; }
    public DateTime withdrawalDate { get; private set; }
    public DateTime? returnDate { get; private set; }
    public DateTime createdAt { get; private set; }
    public DateTime updatedAt { get; private set; }
    public Room room { get; private set; }
    public User user { get; private set; }
    public Report(){
        externalId = Guid.NewGuid();
        createdAt = DateTime.UtcNow;
        updatedAt = DateTime.UtcNow;
        status = Status.Available;
    }
}