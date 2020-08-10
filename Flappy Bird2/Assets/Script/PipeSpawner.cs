using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public Pipe pipeUp;
    public Pipe pipeDown;
    public GameManager gm;
    public GameObject poin;
    public Bird bird;

    public float interval = 2f;
    public float holeSize = 5f;
    public float maxMinOffset = 1f;

    public void Spawn()
    {
        Pipe newPipeUp = Instantiate(pipeUp, transform.position, Quaternion.Euler(0, 0, 180));
        newPipeUp.gameObject.SetActive(true);

        Pipe newPipeDown = Instantiate(pipeDown, transform.position, Quaternion.identity);
        newPipeDown.gameObject.SetActive(true);

        GameObject newPoin = Instantiate(poin, transform.position, Quaternion.identity);
        newPoin.gameObject.SetActive(true);

        float y = maxMinOffset * Mathf.Sin(Time.time);
        newPipeUp.transform.position += Vector3.up * y;
        newPipeDown.transform.position += Vector3.up * y;

        newPipeUp.transform.position += Vector3.up * (holeSize / 2);
        newPipeDown.transform.position += Vector3.down * (holeSize / 2);

        gm.pipe++;

        newPipeDown.pipeNum = gm.pipe;
        newPipeUp.pipeNum = gm.pipe;

    }

    public void Start()
    {
        StartCoroutine("Spawning");
    }

    IEnumerator Spawning()
    {
        while (!bird.isDead)
        {
            Spawn();
            yield return new WaitForSeconds(interval);
        }      
    }
}
