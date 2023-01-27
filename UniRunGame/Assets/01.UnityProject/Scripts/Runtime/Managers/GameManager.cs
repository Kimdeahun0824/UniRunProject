using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = default;
    private const string UIOBJS = "UiObjs";
    private const string SCORE_TEXT_OBJ = "ScoreText";
    private const string GAME_OVER_OBJ = "GameOverObj";
    public bool isGameOver = false;
    private GameObject scoreTextObj = default;
    private GameObject gameOverObj = default;

    private int score = default;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // Init
            isGameOver = false;

            GameObject uiobjs_ = GFunc.GetRootObj(UIOBJS);
            scoreTextObj = uiobjs_.FindChildObj(SCORE_TEXT_OBJ);
            gameOverObj = uiobjs_.FindChildObj(GAME_OVER_OBJ);

            //gameOverObj.SetActive(false);

            score = 0;
        }
        else
        {
            GFunc.LogWarning("[system] GameManager : Duplication object warning");
            Destroy(gameObject);
        }

        score = 0;
    }
    void Start()
    {

    }

    void Update()
    {
        if (isGameOver && Input.GetMouseButtonDown(0))
        {
            GFunc.LoadScene(GFunc.GetActiveScene().name);
        }
    }

    public void AddScore(int score)
    {
        if (isGameOver) { return; }

        score += score;
        scoreTextObj.SetTmpText($"Score : {score}");

    }

    //! 플레이어 사망 시 게임오버를 출력하는 메소드
    public void OnPlayerDead()
    {
        isGameOver = true;
        gameOverObj.SetActive(true);
    }

}
