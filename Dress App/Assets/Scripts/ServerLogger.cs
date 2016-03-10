/*
Egy GUI strukturaban logolja a debug outputot
*/

using UnityEngine;
using System.Collections;

public class ServerLogger : MonoBehaviour {

    private Vector2 scrollPosition;
    private string log;
    private float scaleX, scaleY, btOffsetX, btOffsetY, btWidth, btHeight;

    void Start()
    {
        //Debug.Log eseten a Log metodus hivodik meg
        Application.RegisterLogCallback(Log);
        log = "Debug Console Output \n ------------------------------ \n";

        scaleX = Screen.width / 1280f;
        scaleY = Screen.height / 720f;
        btOffsetX = 950;
        btOffsetY = 620;
        btWidth = 300;
        btHeight = 50;
    }

    void Update()
    {
        scaleX = Screen.width / 1280f;
        scaleY = Screen.height / 720f;
    }

    void OnGUI()
    {
        GUI.BeginGroup(new Rect(scaleX * 10, scaleY * 10, scaleX * 1200, scaleY * 600));
            scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(scaleX * 1180), GUILayout.Height(scaleY * 580));
            GUILayout.Label(log);
            GUILayout.EndScrollView();
        GUI.EndGroup();

        if (GUI.Button(new Rect(btOffsetX * scaleX, btOffsetY * scaleY, btWidth * scaleX, btHeight * scaleY), "Clear log"))
        {
            log = "Debug Console Output \n ------------------------------ \n";
        }
    }

    public void Log(string text, string stackTrace, LogType type)
    {
        log += text + "\n\n";
    }
}
