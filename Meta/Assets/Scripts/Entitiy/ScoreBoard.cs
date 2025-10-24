using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI PlaneGameScore;

    private void Start()
    {
        if (PlaneGameScore == null)
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
    } 
}

