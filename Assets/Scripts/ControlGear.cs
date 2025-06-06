using UnityEngine;

public class ControlGear : MonoBehaviour
{
    public float RotationSpeed;
    Rigidbody2D _rb;

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
        _rb.AddForce(new Vector3(1, 0, 0) * (RotationSpeed*2) * Time.fixedDeltaTime);
    }
}
