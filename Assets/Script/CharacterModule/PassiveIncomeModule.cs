using System;
using UnityEngine;

public class PassiveIncomeModule : CharacterModule
{
    private MoneyManager manager = null;

    private float Timer;
    private float Interval;
    private int Amount;

    public PassiveIncomeModule(GameObject owner)
        :base(owner)
    {
        manager = MoneyManager.Instance();

        if(manager == null)
            throw new ArgumentException("Failed to load money manger");

        UpdatePassiveConfiguration();
        manager.MoneyConfiguration.OnPassiveConfigurationChanged += UpdatePassiveConfiguration;

        Timer = 0;
    }

    public override void Update(float dt)
    { 
        Timer += dt;
        
        if (Interval <= Timer)
        {
            Timer -= Interval;
            manager.AddPassiveIncome(Amount, Owner.transform.position);
            Debug.Log("Interval income : " + Amount + " , now Current Balance : " + manager?.GetBalance());
        }
    }

    private void UpdatePassiveConfiguration()
    {
        Interval = manager.MoneyConfiguration.PassiveIncomeInterval;
        Amount = manager.MoneyConfiguration.PassiveIncomeAmount;
    }

    public override void Dispose()
    {
        base.Dispose();

        manager.MoneyConfiguration.OnPassiveConfigurationChanged -= UpdatePassiveConfiguration;
        manager = null;
    }
}