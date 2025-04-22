namespace BankingAssignment.Classes;

public class Customer
{
    public string Name { get; set; }
    public string ContactInfo { get; set; }
    
    public int CustomerID { get; set; }

    
    public override string ToString()
    {
        return $"{Name}_{ContactInfo}";
    }

}

