using UnityEngine;

public class MoveState : State
{
    [SerializeField] private int _speed;
    private Rigidbody2D _rigidbody;
    private Vector2 _direction;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        Move(h);
    }

    private void Move(float h)
    {
        _direction.x = h;
        _rigidbody.velocity = new Vector2(_direction.x * _speed, _rigidbody.velocity.y) * Time.deltaTime;
    }
}
