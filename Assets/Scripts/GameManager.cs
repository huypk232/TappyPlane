using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject waitingCanvas;
    public GameObject scoreCanvas;
    public GameObject gameOverCanvas;
    public GameObject enviroment;

    public Sprite bronzeMedal, silverMedal, goldMedal;

    public int currentscore;
    public int highscore;

    private Player player;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        currentscore = 0;
        LoadScore();
        player = FindObjectOfType<Player>();
        Time.timeScale = 1f;
    }

    public void StartGame()
    {
        player.enabled = true;
        GameManager.instance.waitingCanvas.SetActive(false);
        GameManager.instance.scoreCanvas.SetActive(true);
        GameManager.instance.enviroment.SetActive(true);
    }

    public void GameOver()
    {
        scoreCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        gameOverCanvas.transform.Find("Score").GetComponent<TextMeshProUGUI>().text = currentscore.ToString();
        SaveScore();
        Time.timeScale = 0f;
        player.enabled = false;
        GameObject medal = gameOverCanvas.transform.Find("Medal").gameObject;
        if(currentscore < 10)
        {
            medal.GetComponent<Image>().overrideSprite = bronzeMedal;
        } else if(currentscore > 10 && currentscore < 30)
        {
            medal.GetComponent<Image>().overrideSprite = silverMedal;
        } else {
            medal.GetComponent<Image>().overrideSprite = goldMedal;
        }
    }

    public void SaveScore()
    {
        if(currentscore > highscore)
        {
            SaveSystem.SaveScore(currentscore);
        }
    }

    public void LoadScore()
    {
        GameData data = SaveSystem.LoadScore();
        if(data != null) highscore = data.highScore;
        else highscore = 0;
    }
 
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void IncreaseScore(int points)
    {
        currentscore += points;
        scoreCanvas.transform.Find("Score").GetComponent<TextMeshProUGUI>().text = currentscore.ToString();
    }
}
