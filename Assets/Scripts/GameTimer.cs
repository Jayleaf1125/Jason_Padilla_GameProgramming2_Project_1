using System;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float timer;
    [SerializeField] TMP_Text timerText;

    private void Start()
    {
        timerText.text = $"Time - {timer}";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Timer();
    }

    void Timer()
    {
        timer -= Time.fixedDeltaTime;
        timer = Mathf.Floor(timer);
        timerText.text = Convert.ToString(timer);

        if (timer <= 0)
        {
            timerText.text = "Time - 0:00";
            return;
        }

        ConvertToTimeText(timer);
    }

    void ConvertToTimeText(float timer)
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        timerText.text = string.Format("Time - {0:00}: {1:00}", minutes, seconds);
    }

}
