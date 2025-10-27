using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColosseumGameManager : MonoBehaviour
{
    public GameObject winner;

    [SerializeField] private PlayerBattleController P1;

    [SerializeField] private PlayerBattleController P2;

    public bool isGaming = true;

     public static ColosseumGameManager Instance { get; private set; }
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        if(P1 == null || P2 == null)
        {
            Debug.LogError("Player Unmatched!!!");
        }
    }

    public void EndGame()
    {
        // 승자 확인
        if (P1.hp > 0)
        {
            winner = P1.gameObject;
            PlayerPrefs.SetInt("P1WinCount", PlayerPrefs.GetInt("P1WinCount", 0) + 1);
        }
        else if (P2.hp > 0)
        {
            winner = P2.gameObject;
            PlayerPrefs.SetInt("P2WinCount", PlayerPrefs.GetInt("P2WinCount", 0) + 1);
        }
        else winner = null;
        
        Debug.Log($"winner is {winner.name}");
        isGaming = false;

        // UI popup
        ColosseumUIManager.Instance.DisplayEndPanel();
        // 
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
