using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10f;

    enum Dir
    {
        Up,
        Down,
    }

    Dir curDir = Dir.Up;

    // 매직넘버 방지
    private float _yUpperEnd = 5f;
    private float _yLowerEnd = -5f;

    private void Start()
    {
    }

    private void Update()
    {
        if (transform.position.y > _yUpperEnd)
        {
            curDir = Dir.Down;
        }
        else if (transform.position.y < _yLowerEnd)
        {
            curDir = Dir.Up;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (curDir == Dir.Up)
                curDir = Dir.Down;
            else if (curDir == Dir.Down)
                curDir = Dir.Up;
        }

        switch (curDir)
        {
            case Dir.Up:
                transform.Translate(Vector2.up * _speed * Time.deltaTime);
                break;
            case Dir.Down:
                transform.Translate(Vector2.down * _speed * Time.deltaTime);
                break;
        }
    }
}
