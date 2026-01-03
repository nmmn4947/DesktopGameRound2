using UnityEngine;

public sealed class Interaction_WorkingInteraction_EarningMoney : InteractionBase_SingleInput
{
    public Interaction_WorkingInteraction_EarningMoney(GameObject owner)
        :base(owner)
    {
        Type = InputActionType.eLeftMousePressed;
    }

    public override void OnPerform()
    {
        MoneyManager.Instance().AddMoney(10);
        Debug.Log("Current Balance is : " + MoneyManager.Instance().GetBalance());
    }
}