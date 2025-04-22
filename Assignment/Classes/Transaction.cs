using BankingAssignment.Enums;
using BankingAssignment.Contracts;

namespace BankingAssignment.Classes;

public class Transaction : ITransaction
{
    public DateTime TransactionTimeStamp
    {
        get { return DateTime.Now; } //set to get the current date and time
    }

    public double Amount { get; set; }
    
    public TransactionTypes Type { get; set;} 
    
    public SavingsAccount SavingsAccount { get; set; }
    
    public CurrentAccount CurrentAccount { get; set; }

    public void ExecuteTransaction()
    {
        throw new NotImplementedException();
    }
}