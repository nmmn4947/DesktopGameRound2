using UnityEngine;

[CreateAssetMenu(
    fileName = "TestCursorBehavior",
    menuName = "CursorBehavior"
)]
public class TestCursor : CursorBehavior
{
    public override void CursorLogic(CursorManager manager)
    {
        Debug.Log("TestCursor");
    }
}
