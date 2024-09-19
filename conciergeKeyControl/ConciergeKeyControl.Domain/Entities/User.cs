public class User{
    public int id { get; private set; }
    public Guid externalId {get; private set;}
    public string name { get; private set;}
    public string email { get; private set;}
    public string password { get; private set;}
    public string iv { get; private set;}
    public DateTime createdAt { get; private set; }
    public DateTime updatedAt { get; private set; }
    public List<Report> reports { get; private set; }
    public User(){
        externalId = Guid.NewGuid();
        createdAt = DateTime.UtcNow;
        updatedAt = DateTime.UtcNow;
    }
    public User setName(string name){
        this.name = name;
        return this;
    }
    public User setEmail(string email){
        this.email = email;
        return this;
    }
    public User setPassword(string password){
        this.password = password;
        return this;
    }
    public User setIv(string iv){
        this.iv = iv;
        return this;
    }
}