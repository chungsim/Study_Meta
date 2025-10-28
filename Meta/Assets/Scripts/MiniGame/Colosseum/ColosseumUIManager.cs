using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ColosseumUIManager : MonoBehaviour
{

    public static ColosseumUIManager Instance { get; private set; }

    [SerializeField] private PlayerBattleController p1BC;
    [SerializeField] private PlayerBattleController p2BC;

    [SerializeField] private UnityEngine.UI.Image p1HpBar;
    [SerializeField] private UnityEngine.UI.Image p2HpBar;

    public GameObject endPanel;
    public TextMeshProUGUI winnerText;

    public UnityEngine.UI.Image winnerImage;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void UpdateHPBar()
    {
        if (p1BC != null && p2BC != null)
        {
            p1HpBar.fillAmount = (float)(p1BC.hp) / (float)(p1BC.maxHp);
            p2HpBar.fillAmount = (float)(p2BC.hp) / (float)(p1BC.maxHp);
        }
    }

    public void DisplayEndPanel()
    {
        endPanel.SetActive(true);
        GameObject winner = ColosseumGameManager.Instance.winner;
        winnerText.text = winner.name + " Win!!!";
        Sprite spriteW = winner.transform.GetComponentInChildren<SpriteRenderer>().sprite;
        Color colorW = winner.transform.GetComponentInChildren<SpriteRenderer>().color;
        winnerImage.sprite = spriteW;
        winnerImage.color = colorW;
    }
}
