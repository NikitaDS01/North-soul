using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    private Rigidbody2D _rb;
    private Transform _transform;
    private bool _isRight;

    public Move(Rigidbody2D rb, Transform transform)
    {
        _rb = rb;
        _transform = transform;
        _isRight = false;
    }

    public void Run(float speed)
    {
        float direction = Move.GetSpeed();
        if(direction != 0)
            Flip(direction < 0);
        if (Input.GetKey(Settings.KeySprint))
            direction *= 2;
        _rb.velocity = new Vector2(direction * speed, 0);
    }
    private void Flip(bool isRight)
    {
        if (_isRight != isRight)
        {
            _isRight = isRight;
            Vector3 scale = _transform.localScale;
            scale.x *= -1f;
            _transform.localScale = scale;
        }
    }
    public static float GetSpeed()
    {
        if (Input.GetKey(KeyCode.D))
        {
            return 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            return -1f;
        }
        return 0;
    }
}
