using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10f;


    Define.PlayerDir curDir = Define.PlayerDir.Up;

    // 매직넘버 방지
    private float _yUpperEnd = 5f;
    private float _yLowerEnd = -5f;

    private void Start()
    {
    }

    // 리펙토링 필요 -> 모듈화
    private void Update()
    {
        if (transform.position.y > _yUpperEnd)
        {
            curDir = Define.PlayerDir.Down;
        }
        else if (transform.position.y < _yLowerEnd)
        {
            curDir = Define.PlayerDir.Up;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (curDir == Define.PlayerDir.Up)
                curDir = Define.PlayerDir.Down;
            else if (curDir == Define.PlayerDir.Down)
                curDir = Define.PlayerDir.Up;
        }

        switch (curDir)
        {
            case Define.PlayerDir.Up:
                transform.Translate(Vector2.up * _speed * Time.deltaTime);
                break;
            case Define.PlayerDir.Down:
                transform.Translate(Vector2.down * _speed * Time.deltaTime);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Score")
        {
            Manager.instance.ScoreUp();
        }
    }
}
