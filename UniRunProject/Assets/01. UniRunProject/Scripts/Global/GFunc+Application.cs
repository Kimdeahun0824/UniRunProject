using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static partial class GFunc
{
    // ! 게임을 종료하는 함수
    public static void QuitThisGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
Application.Quit();
#endif
    }       // QuitThisGame()

    public static void dhKimFunc(this GameObject obj_)
    {
        Debug.Log("내가 만든 쿠기 너를 위해 구웠지");
    }

    // ! 다른 씬을 로드하는 함수
    public static void LoadScene(string sceneName_)
    {
        SceneManager.LoadScene(sceneName_);
    }
}
