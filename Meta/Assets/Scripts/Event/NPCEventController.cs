using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCEventController : MonoBehaviour
{
    [SerializeField] private List<String> scripts;
    [SerializeField] private GameObject sciriptUI;
    [SerializeField] private TextMeshPro sciriptText;
    public void OnDoorStateChanged(bool state)
    {
        int i = UnityEngine.Random.Range(0, scripts.Count);

        if (state)
        {
            sciriptUI.SetActive(true);
            sciriptText.text = scripts[i];
        }
        else
        {
           sciriptUI.SetActive(false);
        }
            
    }
}
