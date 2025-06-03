using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl;

public class PickUp : MonoBehaviour
{
    PlayerMovement _pm;
    SpriteRenderer _sr;
    float score;

    public float SpeedMultiplier;
    public float SpeedMultiplierDuration = 0.5f;

    private void Awake()
    {
        _pm = GetComponent<PlayerMovement>();
        _sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        score = 0;
        DisplayScoreInLog();
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
        }
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
        score++;
        DisplayScoreInLog();
    }

    void DisplayScoreInLog() => Debug.Log(string.Format("Current Score: {0}", score));
}
