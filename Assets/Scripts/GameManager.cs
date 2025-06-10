using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Coin;
    public GameObject SpeedBoost;
    public GameObject TimeBoost;

    public float Range;
    public float CoinTimerInterval;
    public float SpawnSpeedBoostTimerInterval;
    public float SpawnTimeBoostTimerInterval;
    float resetInterval;

    [SerializeField] TMP_Text ScoreText;
    KeepingScore _keepingScore;
    bool IsPlaying;
    AudioManager _audioManager; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnSpeedBoost", 0f, SpawnSpeedBoostTimerInterval);
        InvokeRepeating("SpawnTimeBoost", 0f, SpawnTimeBoostTimerInterval);
        resetInterval = CoinTimerInterval;

        _keepingScore = GetComponentInChildren<KeepingScore>();
        IsPlaying = true;
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        _audioManager.PlayBackgroundMusic();
    }

    // Update is called once per frame
    void Update()
    {
        IsTheGamePlaying();
    }

    public void SetPlaying(bool boolean)
    {
        IsPlaying = boolean;
    }

    void IsTheGamePlaying()
    {
        if (IsPlaying)
        {
            CoinTimer();
            ScoreText.text = $"Score: {_keepingScore.Score}";
        }
        else
        {
            CancelInvoke("SpawnSpeedBoost");
            CancelInvoke("SpawnTimeBoost");
        }
    }

    void CoinTimer()
    {
        CoinTimerInterval -= Time.deltaTime;

        if (CoinTimerInterval <= 0f)
        {
            SpawnCoin();
            CoinTimerInterval = resetInterval;
        }
    }

    void SpawnCoin()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        pos.x = Random.Range(-Range, Range);
        pos.y = Random.Range(-Range, Range);
        pos.z = 0f;
        Instantiate(Coin, pos, Quaternion.identity);
    }

    void SpawnSpeedBoost()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        pos.x = Random.Range(-Range, Range);
        pos.y = Random.Range(-Range, Range);
        pos.z = 0f;
        Instantiate(SpeedBoost, pos, Quaternion.identity);
    }

    void SpawnTimeBoost()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        pos.x = Random.Range(-Range, Range);
        pos.y = Random.Range(-Range, Range);
        pos.z = 0f;
        Instantiate(TimeBoost, pos, Quaternion.identity);
    }
}
