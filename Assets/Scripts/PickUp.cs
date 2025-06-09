using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour
{
    PlayerMovement _pm;
    SpriteRenderer _sr;
    KeepingScore _keepingScore;
    GameTimer _Timer;
    AudioManager _audioManager;

    public float SpeedMultiplier;
    public float SpeedMultiplierDuration = 0.5f;
    public float TimeAmountToIncrease;

    private void Awake()
    {
        _pm = GetComponent<PlayerMovement>();
        _sr = GetComponent<SpriteRenderer>();

        GameObject gm = GameObject.Find("Game Manager");
        _Timer = gm.GetComponent<GameTimer>();
        _keepingScore = gm.GetComponentInChildren<KeepingScore>();

        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
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
        //_audioManager.PlayTimeBoostCollectSound();

    }

    IEnumerator IncreaseSpeed()
    {
        _sr.color = Color.cyan;
        _pm.MovementSpeed *= SpeedMultiplier;
        _audioManager.PlaySpeedBoostSound();
        yield return new WaitForSeconds(SpeedMultiplierDuration);
        _sr.color = Color.white;
        _pm.MovementSpeed /= SpeedMultiplier;
    }

    void AddScore()
    {
        ++(_keepingScore.Score);
        _audioManager.PlayCoinCollect();
    }

}
