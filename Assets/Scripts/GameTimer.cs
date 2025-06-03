using System;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float timer;
    [SerializeField] TMP_Text text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        text.text = Convert.ToString(timer);

        if (timer <= 0)
        {
            text.text = "0";
        }
    }


}
