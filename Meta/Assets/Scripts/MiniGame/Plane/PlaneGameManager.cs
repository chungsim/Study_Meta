using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlaneGameManager : MonoBehaviour
{
    static PlaneGameManager planeGameManager;
    public static PlaneGameManager InstancePlaneGame { get { return planeGameManager; } }

    private int currentScore = 0;

    UIManager uiManager;

    Player player;

    public UIManager UIManager {get { return uiManager; }}

    private void Awake()
    {
        planeGameManager = this;
        uiManager = FindObjectOfType<UIManager>();
        player = FindAnyObjectByType<Player>();
        //Time.timeScale = 0f;
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
        //player.PausePlayerToggle();
    }

    public void GameStart()
    {
        uiManager.SetStart();
        StartCoroutine("StartCountdown", 3);       
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        uiManager.SetRestart();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void AddScore(int score)
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);
    }

    IEnumerator StartCountdown(int sec)
    {
        
        float time = 0.0f;

        Debug.Log("Couroutine Start");

        while (time < sec)
        {
            time += Time.deltaTime;

            if (time > sec)
            {
                time = sec;
            }

            uiManager.CountDownText(time);
            yield return null;
        }
        player.PausePlayerToggle();     
    }
}
