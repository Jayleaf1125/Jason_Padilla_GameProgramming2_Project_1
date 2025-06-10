using UnityEngine;

public class ControlGear : MonoBehaviour
{
    public float RotationSpeed;
    Rigidbody2D _rb;

    float randX = 1;
    float randY = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        RotateGear();
        MoveGear();
    }
    void RotateGear()
    {
        transform.Rotate(0, 0, RotationSpeed);
    }

    void MoveGear()
    {
        _rb.AddForce(new Vector3(randX, randY, 0) * (RotationSpeed*2f) * (Time.fixedDeltaTime * 1.5f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float x = Random.Range(0, 5);
        float y = Random.Range(0, 5);

        randX = x;
        randY = y;

    }
}
