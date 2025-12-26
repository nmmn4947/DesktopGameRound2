using UnityEngine;
using System.Collections.Generic;

public class UITEST : MonoBehaviour
{
    private List<string> logs = new();
    private bool show;

    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.BackQuote))
            show = !show;*/
        show = true;
    }

    void HandleLog(string log, string stack, LogType type)
    {
        logs.Add($"[{type}] {log}");
        if (logs.Count > 30) logs.RemoveAt(0);
    }

    void OnGUI()
    {
        if (!show) return;

        GUI.Box(new Rect(5, 5, Screen.width - 10, 400), "");
        for (int i = 0; i < logs.Count; i++)
        {
            GUI.Label(new Rect(10, 30 + i * 18, Screen.width - 20, 20), logs[i]);
        }
    }
}