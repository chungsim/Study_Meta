using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI PlaneGameScore;

    public TextMeshProUGUI ColosseumScore;

    private void Start()
    {
        if (PlaneGameScore == null)
        {
            Debug.LogError("No planegametext matched");
        }

        if (ColosseumScore == null)
        {
            Debug.LogError("No planegametext matched");
        }
    }

    private void OnEnable()
    {
        UpdateScore();
    }

    public void UpdateScore()
    {
        PlaneGameScore.text = PlayerPrefs.GetInt("PlaneGameRecord", 0).ToString();

        ColosseumScore.text = PlayerPrefs.GetInt("P1WinCount", 0) + " : " + PlayerPrefs.GetInt("P2WinCount", 0);
    } 
}

