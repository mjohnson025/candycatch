using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int score = 0;
    bool gameOver = false;
    public Text scoreText;
    public int lives;
    public GameObject livesHolder;
    public GameObject gameOverPanel;



    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementScore()
    {
        if (!gameOver)
        {
            score++;
            scoreText.text = score.ToString();
        }
    }

    public void DecrementLife()
    {
        if (lives > 0)
        {
            lives--;
           // if(livesholder.transform.childCount > 0) { 
            livesHolder.transform.GetChild(lives).gameObject.SetActive(false);
           // }

        }

        if (lives <= 0)
        {
            gameOver = true;
            GameOver();
        }
    }

    public void GameOver()
    {
        CandySpawner.instance.StopSpawn();
        GameObject.Find("Player").GetComponent<PlayerController>().canMove = false;
        gameOverPanel.SetActive(true);



    }

    public void Replay()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
