using UnityEngine;

public class UIComponent_ChangeGameState : MonoBehaviour
{
    [SerializeField] private UIUtil_ChangeGameState changeAction;

    public void OnClick() => changeAction?.ChangeGameState();
}
    