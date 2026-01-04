// update the currency configuration later
using System;

public class MoneyConfiguration
{
    public float PassiveIncomeInterval {get; private set; }
    public int PassiveIncomeAmount {get; private set; }

    public int ActiveIncomeAmount {get; private set; }

    public event Action OnPassiveConfigurationChanged;
    public event Action OnActiveConfigurationChanged;

    public MoneyConfiguration()
    {
        PassiveIncomeInterval = 1.0f;
        PassiveIncomeAmount = 10;
        ActiveIncomeAmount = 5;
    }

    public void SetPassiveIncome(int amount, float interval)
    {
        PassiveIncomeAmount = amount;
        PassiveIncomeInterval = interval;

        OnPassiveConfigurationChanged?.Invoke();
    }

    public void SetActiveIncome(int amount)
    {
        ActiveIncomeAmount = amount;

        OnActiveConfigurationChanged?.Invoke();
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