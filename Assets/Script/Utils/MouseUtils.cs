using UnityEngine;

public static class MouseUtil
{
    public class MouseFollowUtil
    {
        public static Vector3 GetMouseFollowPosition(Vector3 currentWorldPos)
        {
            Vector3 mouse = Input.mousePosition;
            mouse.z = Camera.main.WorldToScreenPoint(currentWorldPos).z;
            
            return Camera.main.ScreenToWorldPoint(mouse);
        }
    }
}