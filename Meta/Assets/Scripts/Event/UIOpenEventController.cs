using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOpenEventController : MonoBehaviour
{
    [SerializeField] private GameObject targetUI;
    public void OnDoorStateChanged(bool state)
    {
        if (state)
        {
            targetUI.SetActive(true);
        }
        else
        {
           targetUI.SetActive(false);
        }
            
    }
}
