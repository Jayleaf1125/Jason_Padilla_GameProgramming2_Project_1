using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed;
    Rigidbody2D _rb;
    Vector3 _direction;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.AddForce(Direction() * MovementSpeed * Time.fixedDeltaTime);
    }

    Vector3 Direction()
    {
        float x_movement = Input.GetAxis("Horizontal");
        float y_movement = Input.GetAxis("Vertical");

        _direction = new Vector3(x_movement, y_movement, 0); 

        return _direction;
    }
}
