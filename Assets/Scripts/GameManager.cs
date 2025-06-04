
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Coin;
    public GameObject SpeedBoost;
    public GameObject TimeBoost;

    public float Range;
    public float CoinTimerInterval;
    public float SpeedBoostTimerInterval;
    public float TimeBoostTimerInterval;
    float resetInterval;

    [SerializeField] TMP_Text ScoreText;
    KeepingScore _keepingScore;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnSpeedBoost", 0f, SpeedBoostTimerInterval);
        InvokeRepeating("SpawnTimeBoost", 0f, TimeBoostTimerInterval);
        resetInterval = CoinTimerInterval;

        _keepingScore = GetComponentInChildren<KeepingScore>();
    }

    // Update is called once per frame
    void Update()
    {
        CoinTimer();
        ScoreText.text = $"{_keepingScore.Score}";
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
