using UnityEngine;
using TMPro;

public class ScreenManager : MonoBehaviour
{
    public GameObject GameOverScreen;
    public GameObject GameManager;

    public TMP_Text TimeText;
    public TMP_Text ScoreText;
    public TMP_Text TotalScoreText;
    public TMP_Text GameOverText;

    bool IsGameOver;
    GameManager _gm;

    //float Time;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {        
        IsGameOver = false;
        _gm = GameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeText.text == "Time - 0:00" && !IsGameOver)
        {
            SetOn();
            SetOff();
        }
    }

    void SetOn()
    {
        TotalScoreText.text = $"{ScoreText.text}";
        GameOverScreen.SetActive(true);
        TotalScoreText.gameObject.SetActive(true);
        GameOverText.gameObject.SetActive(true);
        IsGameOver = true;
    }

    void SetOff()
    {
        TimeText.gameObject.SetActive(false);
        ScoreText.gameObject.SetActive(false);
        _gm.SetPlaying(false);
        GameManager.SetActive(false);
    }
}