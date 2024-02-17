using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;

    private void Start()
    {
        
    }

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);

        if (transform.position.x < -15f)
            Destroy(gameObject);
    }
}
