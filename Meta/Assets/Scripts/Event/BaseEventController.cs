using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEventController : MonoBehaviour
{
    //현재 상호작용 가능한 오브젝트의 리스트들
    private List<GameObject> interactEvObs = new List<GameObject>();

    // 상호작용 가능한 오브젝트와 접촉 시
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EventObject"))
        {
            interactEvObs.Add(collision.gameObject);
            HighlightEvOb(collision.gameObject);
            Debug.Log(interactEvObs.Count);           
        }
    }

    // 상호작용 가능 오브젝트와 떨어졌을 시
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EventObject"))
        {
            interactEvObs.Remove(collision.gameObject);
            DehighlightEvOb(collision.gameObject);
            Debug.Log(interactEvObs.Count);
        }
    }

    private void HighlightEvOb(GameObject targetOb)
    {
        targetOb.transform.Find("HighlightSprite").gameObject.SetActive(true);
    }
    
    private void DehighlightEvOb(GameObject targetOb)
    {
        targetOb.transform.Find("HighlightSprite").gameObject.SetActive(false);
    }
}
