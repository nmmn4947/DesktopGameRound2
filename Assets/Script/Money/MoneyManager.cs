// update the currency configuration later
public class MoneyData
{
    public int Balance;
}

public class MoneyManager
{
    public static MoneyManager Instance_ = null;
    
    private MoneyData MoneyData;

    public static MoneyManager Instance()
    {
        if(Instance_ != null)
            return Instance_;

        Instance_ = new();

        return Instance_;
    }

    private MoneyManager()
    {
        // add the logic for load logic 
        InitializeBalance();
    }

    public void AddMoney(int amount) => MoneyData.Balance += amount;
    
    public bool SpendMoney(int amount)
    {
        if(MoneyData.Balance < amount)
            return false;

        MoneyData.Balance -= amount;
        return true;
    }

    public int GetBalance() => MoneyData.Balance;

    // for test
    public void InitializeBalance()
    {
        MoneyData = new();
        MoneyData.Balance = 0;
    }
}