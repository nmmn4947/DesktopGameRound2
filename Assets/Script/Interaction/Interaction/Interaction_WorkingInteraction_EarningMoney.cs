using UnityEngine;

public sealed class Interaction_WorkingInteraction_EarningMoney : InteractionBase_SingleInput
{
    MoneyManager manager = null;
    private int IncomeAmount;

    public void UpdateIncomeAmount() => IncomeAmount = manager.MoneyConfiguration.ActiveIncomeAmount;

    public Interaction_WorkingInteraction_EarningMoney(GameObject owner)
        :base(owner)
    {
        Type = InputActionType.eLeftMouseTapped;

        manager = MoneyManager.Instance();
        UpdateIncomeAmount();
        manager.MoneyConfiguration.OnActiveConfigurationChanged += UpdateIncomeAmount;
    }

    public override void OnPerform()
    {
        MoneyManager.Instance().AddActiveIncome(IncomeAmount, Owner.transform.position);
        Debug.Log("Current Balance is : " + MoneyManager.Instance().GetBalance());
    }

    public override void Dispose()
    {
        base.Dispose();

        manager.MoneyConfiguration.OnActiveConfigurationChanged -= UpdateIncomeAmount;
        manager = null;
    }
}