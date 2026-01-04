// update the currency configuration later
using System;

public class MoneyConfiguration
{
    public float PassiveIncomeInterval {get; private set; }
    public int PassiveIncomeAmount {get; private set; }

    public event Action OnConfigurationChanged;

    public MoneyConfiguration()
    {
        PassiveIncomeInterval = 1.0f;
        PassiveIncomeAmount = 10;
    }

    public void SetPassiveIncome(int amount, float interval)
    {
        PassiveIncomeAmount = amount;
        PassiveIncomeInterval = interval;

        OnConfigurationChanged?.Invoke();
    }
}

public class MoneyData
{
    public int Balance;

    public MoneyData() => Balance = 0;
}

public class MoneyManager
{
    public static MoneyManager Instance_ = null;

    public MoneyConfiguration MoneyConfiguration { get; private set; }
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
        MoneyConfiguration = new();
        MoneyData = new();
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
}