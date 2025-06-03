using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Coin;
    public GameObject SpeedBoost;
    public float Range;
    public float CoinTimerInterval;
    public float SpeedBoostTimerInterval;
    float resetInterval;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnSpeedBoost", 0f, SpeedBoostTimerInterval);
        resetInterval = CoinTimerInterval;
    }

    // Update is called once per frame
    void Update()
    {
        CoinTimerInterval -= Time.deltaTime;

        if(CoinTimerInterval <= 0f)
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

    void SpawnSpeedBoost(GameObject GameObj)
    {
        Vector3 pos = new Vector3(0, 0, 0);
        pos.x = Random.Range(-Range, Range);
        pos.y = Random.Range(-Range, Range);
        pos.z = 0f;
        Instantiate(SpeedBoost, pos, Quaternion.identity);
    }
}
