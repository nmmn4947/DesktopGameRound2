using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class Transparent3D : MonoBehaviour
{
    [DllImport("user32.dll")]
    public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    [DllImport("user32.dll")]
    private static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

    [DllImport("user32.dll", SetLastError = true)]
    static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

    private struct MARGINS
    {
        public int cxLeftWidth;
        public int cxRightWidth;
        public int cxTopHeight;
        public int cxBottomHeight;
    }

    [DllImport("Dwmapi.dll")]
    private static extern uint DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS margins);

    const int GWL_EXSTYLE = -20;

    const uint WS_EX_LAYERED = 0x00080000;
    const uint WS_EX_TRANSPARENT = 0x00000020;

    private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

    private IntPtr hWnd;

    private int layerMask;
    private Vector3 PrevMousePos = new Vector3(0, 0, -1);


    /// ////////////////// /// ////////////////// /// ////////////////// /// ////////////////// /// //////////////////
    public bool isTabOff = false;
    
    public static Transparent3D instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        instance = this;
    }

    private void Start()
    {
        //MessageBox(new IntPtr(0), "Hello World!", "HelloDialog", 0);

#if !UNITY_EDITOR
        hWnd = GetActiveWindow();

        SetWindowPos(hWnd, HWND_TOPMOST, 0, 0, 0, 0, 0);

        SetWindowLong(hWnd, GWL_EXSTYLE, WS_EX_LAYERED | WS_EX_TRANSPARENT);

        MARGINS margins = new MARGINS { cxLeftWidth = -1 };
        DwmExtendFrameIntoClientArea(hWnd, ref margins);
#endif
        Application.runInBackground = true;

        // Ignore objects on the "ThruLayer"
        layerMask = ~LayerMask.GetMask("thru");
    }

    private void Update()
    {
        /*        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool isOverUI = Physics.Raycast(ray, out hit);
                if (hit.collider.tag == "thru")
                {
                    isOverUI = false;
                }
                Debug.Log(isOverUI);*/

    /*        int layerMask = ~LayerMask.GetMask("thru"); // All layers except ThruLayer
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity, layerMask);

            bool isOverUI = false;

            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.tag != "thru")
                {
                    isOverUI = true;
                    break;
                }
            }
            SetClickthrough(!isOverUI);*/

        Vector3 currentMousePos = Input.mousePosition;

        if(PrevMousePos != currentMousePos)
        {
            Ray ray = Camera.main.ScreenPointToRay(currentMousePos);
            RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity, layerMask);

            bool isOverUI = false;

            foreach (var hit in hits)
            {
                if (hit.collider.gameObject.layer != LayerMask.NameToLayer("thru"))
                {
                    isOverUI = true;  
                    break;
                }
            }
            
            SetClickthrough(!isOverUI);
        }

                /*
                var clickable = hit.collider.GetComponent<IClickable>();
                if (clickable != null && Input.GetMouseButtonDown(0))
                {
                    clickable.OnMouseClick();
                    break;
                }
                if (clickable != null && Input.GetMouseButton(0))
                {
                    clickable.OnMouseHold();
                    break;
                }
                if (clickable != null && Input.GetMouseButtonUp(0))
                {
                    clickable.OnMouseRelease();
                    break;
                }
                /*                if (clickable != null && Input.GetMouseButtonDown(2))
                                {
                                    clickable.OnMiddleMouseClick();
                                    break;
                                }*//*
                if (clickable != null && Input.GetMouseButton(2))
                {
                    clickable.OnMiddleMouseHold();
                    break;
                }
                if (clickable != null && Input.GetMouseButtonUp(2))
                {
                    clickable.OnMiddleMouseRelease();
                    break;
                }*/
    }

    public void SetClickthrough(bool clickthrough)
    {
        if (clickthrough)
            SetWindowLong(hWnd, GWL_EXSTYLE, WS_EX_LAYERED | WS_EX_TRANSPARENT);
        else
            SetWindowLong(hWnd, GWL_EXSTYLE, WS_EX_LAYERED);
    }
    
    void OnApplicationFocus(bool hasFocus)
    {
        isTabOff = !hasFocus;
    }
}
