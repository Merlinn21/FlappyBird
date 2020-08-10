using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed = 2f;
    public int pipeNum = 1;
    private float minNum = 3f;
    private float maxNum = 6f;
    private bool startMove = false;
    public Bird bird;

    private void Update()
    {
        if(!bird.isDead)
            Move();

        if (pipeNum % 2 == 0 && startMove == false)
            RandomPipe();
    }

    private void Move()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
    }

    public void RandomPipe()
    {
        startMove = true;
        StartCoroutine("ChangeSize");
    }

    IEnumerator ChangeSize()
    {
        float randNum = Random.Range(minNum, maxNum);
        transform.position += Vector3.up * (randNum / 2);
        yield return new WaitForSeconds(4f);
        StartCoroutine("GoDown");     
    }

    IEnumerator GoDown()
    {
        float randNum = Random.Range(minNum, maxNum);
        transform.position += Vector3.down * (randNum / 2);
        yield return new WaitForSeconds(4f);
        StartCoroutine("ChangeSize");
    }
}
