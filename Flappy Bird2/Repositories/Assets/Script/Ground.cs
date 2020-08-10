using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public Bird bird;
    public float speed = 2f;
    public Transform nextPos;

    private void Update()
    {
        if (!bird.isDead)
        {
            Move();
        }
    }

    public void Move()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
    }

    public void SetNextGround(GameObject ground)
    {
        if (ground != null)
        {
            ground.transform.position = nextPos.position;
        }
    }

}
