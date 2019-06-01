using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    public Text scoreText;
    int score;

    public GameObject gameover;

    // Start is called before the first frame update
    void Start()
    {
        gameover.SetActive(false);
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void scoreUpdate()
    {
        score += 1;
    }

    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void GameOver()
    {
        gameover.SetActive(true);
    }
}
