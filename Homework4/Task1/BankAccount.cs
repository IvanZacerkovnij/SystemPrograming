namespace Homework4.Task1;

public class BankAccount
{
    private readonly object _lock = new object();
    
    public int Id { get; set; }
    public decimal Balance { get; set; }
    
    public bool IsBlocked { get; set; }

    public void Deposit(decimal amount)
    {
        lock (_lock)
        {
            if (IsBlocked)
            {
                Console.WriteLine("Account is blocked");
                return;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Amount must be greater than zero");
                return;
            }
            Balance += amount;
        }
    }

    public void Withdraw(decimal amount)
    {
        lock (_lock)
        {
            if (IsBlocked)
            {
                Console.WriteLine("Account is blocked");
                return;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Amount must be greater than zero");
                return;
            }

            if (amount > Balance)
            {
                Console.WriteLine("Not enough money");
                return;
            }
            Balance -= amount;
        }
    }

    public void Block()
    {
        lock (_lock)
        {
            if (IsBlocked)
            {
                Console.WriteLine("Account is already blocked");
                return;
            }
            IsBlocked = true;
        }
    }

    public void Unblock()
    {
        lock (_lock)
        {
            if (!IsBlocked)
            {
                Console.WriteLine("Account is not blocked");
            }

            IsBlocked = false;
        }
    }

    public override string ToString()
    {
        return $"Id: {Id}, Balance: {Balance} , IsBlocked: {IsBlocked}";
    }
}