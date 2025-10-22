using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestEventController : MonoBehaviour
{
    public void OnDoorStateChanged(bool state)
    {
        if (state)
            Debug.Log("문이 열렸습니다!");
        else
            Debug.Log("문이 닫혔습니다!");
    }
}
