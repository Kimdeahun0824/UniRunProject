using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GFunc_Application
{
    public static void QuitThisGame()
    {
#if UNITY_EDITOR
UnityEditor.EditorApplication.isPlaying = false;
#else
Application.Quit();
#endif
    }       // QuitThisGame()
}
