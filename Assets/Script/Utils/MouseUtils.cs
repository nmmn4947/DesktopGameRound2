using System;
using UnityEngine;

public static class MouseUtil
{
    public class MouseFollowUtil
    {
        public static Camera Camera = null;

        public static void InitializeCamera() => Camera = Camera.main;

        public static Vector3 GetMouseFollowPosition(Vector3 currentWorldPos)
        {
            if(Camera == null)
                throw new ArgumentException("Loading main camera is failed");

            Vector3 mouse = Input.mousePosition;
            mouse.z = Camera.WorldToScreenPoint(currentWorldPos).z;
            
            return Camera.ScreenToWorldPoint(mouse);
        }
    }
}