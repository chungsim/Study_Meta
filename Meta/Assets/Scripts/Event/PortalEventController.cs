using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalEventController : MonoBehaviour
{
    [SerializeField] private string sceneName;
    public void OnDoorStateChanged(bool state)
    {
        if (state)
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
           Debug.Log("포탈이 닫혔습니다!"); 
        }
            
    }
}
