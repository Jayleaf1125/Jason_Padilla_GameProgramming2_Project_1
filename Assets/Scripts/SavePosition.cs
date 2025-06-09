using UnityEngine;

public class SavePosition : MonoBehaviour
{
    Vector3 PosSave;
    bool IsPositionBeingSaved;
    public GameObject SaveLocationPrefab;
    GameObject LocationObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsPositionBeingSaved = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && !IsPositionBeingSaved)
        {
            SavePos();
        } else if (Input.GetKeyUp(KeyCode.Space) && IsPositionBeingSaved)
        {
            LoadPos();
        }
    }

    void SavePos()
    {
        PosSave = new Vector3(this.transform.position.x, this.transform.position.y, 0);
        LocationObj = Instantiate(SaveLocationPrefab, PosSave, Quaternion.identity);
        IsPositionBeingSaved = true;
    }

    void LoadPos()
    {
        this.transform.position = PosSave;
        Destroy(LocationObj);
        PosSave = Vector3.zero;
        IsPositionBeingSaved = false;
    }


}
