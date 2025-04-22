using System.Buffers;
using BankingAssignment.Enums;

namespace BankingAssignment.Classes;

public abstract class Account
{
    //PRIVATE FIELDS
    private string _accountNumber { get; set; }

    private double _balance { get; set; }

    private AccountTypes _accountType { get; set; }
    
    //PUBLIC METHODS

    public string AccountNumber() 
    {
        return _accountNumber;
    }
    

    public AccountTypes AccountType() 
    {
        return _accountType;
    }

    public abstract void Deposit(double amount); //abstract methods must be called in derived classes

    public abstract void Withdraw(double amount); //abstract method

    //PUBLIC CONSTRUCTOR
    public Account (string acno, double amount, AccountTypes accountType)
    {
        _accountNumber = acno;
        _balance = amount;
        _accountType = accountType;
    }

    public void SetBalance(double amount)
    {
        this._balance = amount;
    }

    public double GetBalance()
    {
        return _balance;
    }

}





public class SavingsAccount : Account
{

    private double interestRate;
    
    public SavingsAccount(string acno, double amount) : base(acno, amount, AccountTypes.Savings)
    {
    }

    public override void Deposit(double DepositAmount)
    {
        try
        {
            if (DepositAmount <= 0)
            {
                Console.WriteLine("Your deposit amount must be greater than 0");
            }
            else
            {
                SetBalance(GetBalance()+DepositAmount);
                Console.WriteLine($"Amount Deposited: {DepositAmount}");
                Console.WriteLine($"Current Balance: {GetBalance()}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public override void Withdraw(double amount)
    {
        if (amount > GetBalance())
        {
            Console.WriteLine("Your acccunt has insufficient funds!");
        }
        else if (amount <= 0)
        {
            Console.WriteLine("No overdraft in Savings");
        }
        else
        {
            SetBalance(GetBalance() - amount);
            Console.WriteLine($"Amount Withdrawn: {amount}");
            Console.WriteLine($"Current Balance: {GetBalance()}");
        }
    }

    public void ApplyInterest(double amount)
    {
        interestRate =  amount * 0.2;
        SetBalance(GetBalance() +interestRate);
    }
    
    

}


public class CurrentAccount : Account
{
    public CurrentAccount(string acno, double amount) : base(acno, amount,AccountTypes.Current)
    {
    }

    private int OverdraftLimit = -1000;

    public override void Deposit(double DepositAmount)
    {
        try
        {
            if (DepositAmount <= 0)
            {
                Console.WriteLine("Your deposit amount must be greater than 0");
            }
            else
            {
                SetBalance(GetBalance() + DepositAmount);
                Console.WriteLine($"Amount Deposited: {DepositAmount}");
                Console.WriteLine($"CurentBalance: {GetBalance()}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public override void Withdraw(double WithdrawalAmount)
    {
        if (WithdrawalAmount >= GetBalance() - OverdraftLimit)
        {
            Console.WriteLine("Your account cannot withdraw past the overdraft limit!");
        }
        else
        {
            SetBalance(GetBalance() - WithdrawalAmount);
            Console.WriteLine($"Withdrawn amount: {WithdrawalAmount}");
            Console.WriteLine($"Current balance: {GetBalance()}");
        }

    }
}
