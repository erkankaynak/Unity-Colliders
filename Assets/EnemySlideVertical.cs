using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlideVertical : MonoBehaviour
{
    public enum DIRECTION { LEFT, RIGHT, UP, DOWN }
    public float speed;
    public DIRECTION direction;

    private Vector3 _direction;
    private float timer;

    private void Start()
    {
        if (direction == DIRECTION.LEFT) _direction = Vector3.left;
        if (direction == DIRECTION.RIGHT) _direction = Vector3.right;
        if (direction == DIRECTION.UP) _direction = Vector3.forward;
        if (direction == DIRECTION.DOWN) _direction = Vector3.back;

    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 2) // 3 seconds
        {
            timer = 0; // reset timer
            _direction = _direction * -1; // flip direction
        }

        transform.Translate(_direction * speed * Time.deltaTime);
    }
}
