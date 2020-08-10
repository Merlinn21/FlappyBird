using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int poin = 0;
    public int pipe = 0;
    public Text text;
    public GameObject button;
    public GameObject restart;

    public void UpdateScore()
    {
        text.text = poin.ToString();
    }
    
    public void GameOver()
    {
        button.SetActive(true);
        restart.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }
}
