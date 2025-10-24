using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI bestScoreText_;

    public GameObject uiBack;
    public GameObject restartButton;
    public GameObject exitButton;
    public GameObject startButton;

    public GameObject gameDescript;

    public TextMeshProUGUI countText;

    // Start is called before the first frame update
    void Start()
    {
        if (scoreText == null)
        {
            Debug.LogError("No restartText");
        }

        if (bestScoreText == null)
        {
            Debug.LogError("No scoreText");
        }

        //restartText.gameObject.SetActive(false);
        restartButton.SetActive(false);
        exitButton.SetActive(false);
        uiBack.SetActive(false);
        bestScoreText.gameObject.SetActive(false);
        bestScoreText_.gameObject.SetActive(false);
    }


    public void SetRestart()
    {
        //restartText.gameObject.SetActive(true);
        restartButton.SetActive(true);
        exitButton.SetActive(true);
        uiBack.SetActive(true);
        bestScoreText.gameObject.SetActive(true);
        bestScoreText_.gameObject.SetActive(true);

        bestScoreText.text = PlayerPrefs.GetInt("PlaneGameRecord", 0).ToString();
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void SetStart()
    {
        startButton.SetActive(false);
        gameDescript.gameObject.SetActive(false);
        countText.gameObject.SetActive(true);
    }

    public void CountDownText(float sec)
    {
        countText.text = ((int)sec).ToString();
        if(sec <= 0)
        {
            countText.gameObject.SetActive(false);
        }
    }
}
