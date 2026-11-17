namespace ATM;

public class Account
{
    public int Balance { get; private set; }

    public Account(int initialBalance) 
    {
        if (initialBalance >= 0)
        {
            Balance = initialBalance;
        }
    }

    public int GetBalance() 
    {
        return Balance;
    }

    public bool Withdraw(int amount)
    {
        if(amount > 0 && Balance - amount >= 0 && (amount % 100) == 0)
        {
            Balance -= amount;
            return true;
        }
        else
        {
            return false;
        }
        
    }
    
    public bool Deposit(int amount)
    {
        if(amount > 0 && (amount % 100) == 0) 
        {
            Balance += amount;
            return true;
        }
        else
        {
            return false;
        }
    }
    
}