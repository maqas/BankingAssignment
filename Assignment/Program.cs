// See https://aka.ms/new-console-template for more information


using BankingAssignment.Classes;
using BankingAssignment.Enums;


namespace BankingAssignment
{
    class Assignment
    {
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Hello and welcome to Banking Assignment!");
            Customer randomCustomer = GetCustInfo();
            Console.WriteLine("Thank you foe being our customer,which account you want to create: \n1.Savings Account 2.Current Account");
            string choice = Console.ReadLine();
            if (choice == "1" || choice.Contains("Savings"))
            {
                CreateSavingsAccount(randomCustomer);
            }
            else if (choice == "2" || choice.Contains("Current Account"))
            {
               CreateCurrentAccount(randomCustomer);
            }
            
        }




      

        public static Customer GetCustInfo()
        {
            Console.WriteLine("--THANK YOU FOR CHOOSING TO BANK WITH US--");
            
            Console.WriteLine("Hello, please enter you name");
            string CustName = Console.ReadLine();
            
            
            Console.WriteLine("Please also enter your contact details");
            string contact = Console.ReadLine();
            
            
            
            
            return new Customer
            {
                Name = CustName,
                ContactInfo = contact,
                CustomerID = 1
                
            };

            

        }

        private static void CreateSavingsAccount(Customer cust)
        {
            Console.WriteLine("----Create a Savings account----");
            
            Console.WriteLine("Please enter account number");
            string acno = Console.ReadLine();

            try
            {
                Console.WriteLine("Please enter initial Savings amount");
                string amount = Console.ReadLine();
                double dAmount = double.Parse(amount);
                SavingsAccount account = new SavingsAccount(acno, dAmount);
                Console.WriteLine($"{AccountTypes.Savings} account created successfully for {cust.Name} with intial balance of {dAmount}");
                MakeTransaction(account);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
          
            
            
            
        }


        private static void CreateCurrentAccount(Customer cust)
        {
            Console.WriteLine("----Create a Current Account----");
            
            Console.WriteLine("Please enter account number");
            string acno = Console.ReadLine();

            try
            {
                Console.WriteLine("Please enter initial Current amount");
                string amount = Console.ReadLine();
                double dAmount = double.Parse(amount);
                CurrentAccount account = new CurrentAccount(acno, dAmount);
                Console.WriteLine($"{AccountTypes.Current} account created successfully for {cust.Name} with Initial balance of {dAmount}");
                MakeTransaction(account);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        private static void MakeTransaction(Account account)
        {
            List<Transaction> transactions = new List<Transaction>();
            
            Console.WriteLine("Choose transaction: \n1.Deposit 2.Withdraw");
            string trans = Console.ReadLine();

            if (trans.ToLower() == "deposit" || trans == "1")
            {
                Console.WriteLine("Enter amount to deposit");
                string amount = Console.ReadLine();
                double dAmount = double.Parse(amount);
                account.Deposit(dAmount);
                
            }
            else if (trans.ToLower() == "withdraw" || trans == "2")
            {
                Console.WriteLine("Enter amount to withdraw");
                string amount = Console.ReadLine();
                double dAmount = double.Parse(amount);
                account.Withdraw(dAmount);
                
            }
            
        }

























    }
    
    
    
}


