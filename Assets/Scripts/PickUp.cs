using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class PickUp : MonoBehaviour
{
    PlayerMovement _pm;
    SpriteRenderer _sr;
    float score;
    [SerializeField] TMP_Text ScoreText;
    GameTimer _Timer;

    public float SpeedMultiplier;
    public float SpeedMultiplierDuration = 0.5f;

    public float TimeAmountToIncrease;

    private void Awake()
    {
        _pm = GetComponent<PlayerMovement>();
        _sr = GetComponent<SpriteRenderer>();
        _Timer = GameObject.Find("Game Manager").GetComponent<GameTimer>();
    }

    private void Start()
    {
        score = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandlePickUp(collision.tag);
        Destroy(collision.gameObject);
    }

    void HandlePickUp(string tag)
    {
        switch(tag)
        {
            case "Coin":
                AddScore();
                break;
            case "Speed Boost":
                StartCoroutine(IncreaseSpeed());
                break;
            case "Time Boost":
                IncreaseTime();
                break;
        }
    }

    void IncreaseTime()
    {
        _Timer.timer += TimeAmountToIncrease;
    }

    IEnumerator IncreaseSpeed()
    {
        _sr.color = Color.cyan;
        _pm.MovementSpeed *= SpeedMultiplier;
        yield return new WaitForSeconds(SpeedMultiplierDuration);
        _sr.color = Color.white;
        _pm.MovementSpeed /= SpeedMultiplier;
    }

    void AddScore()
    {
        ScoreText.text = string.Format("{0}", ++score);        
    }

    void DisplayScoreInLog() => Debug.Log(string.Format("Current Score: {0}", score));
}
