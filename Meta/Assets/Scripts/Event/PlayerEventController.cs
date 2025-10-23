using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventController : MonoBehaviour
{
    //현재 상호작용 가능한 오브젝트의 리스트들
    private List<GameObject> interactEvObs = new List<GameObject>();

    void Update()
    {
        if (Input.GetKey("e"))
        {
            if(interactEvObs.Count > 0)
            {
                interactEvent();
            }
        }
    }

    // 상호작용 가능한 오브젝트와 접촉 시
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EventObject"))
        {
            if(interactEvObs.Count > 0)
            {
                DehighlightEvOb();
            }
            interactEvObs.Add(collision.gameObject);
            HighlightEvOb();
            Debug.Log(interactEvObs.Count);           
        }
    }

    // 상호작용 가능 오브젝트와 떨어졌을 시
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EventObject"))
        {
            if(interactEvObs.Count > 0)
            {
              interactEvObs[interactEvObs.Count - 1].GetComponent<BaseEventObjectController>().IsActive = false;  
            }           
            DehighlightEvOb();
            interactEvObs.Remove(collision.gameObject);
            if (interactEvObs.Count > 0)
            {
                HighlightEvOb();
            }
            Debug.Log(interactEvObs.Count);
        }
    }
    
    private void interactEvent()
    {
        if(interactEvObs.Count > 0)
        {
            //대상의 이벤트 실행
            interactEvObs[interactEvObs.Count - 1].GetComponent<BaseEventObjectController>().IsActive = true;
        }
    }

    private void HighlightEvOb()
    {
        interactEvObs[interactEvObs.Count - 1].transform.Find("HighlightSprite").gameObject.SetActive(true);
        transform.Find("ButtonPopup").gameObject.SetActive(true);
        //targetOb.transform.Find("HighlightSprite").gameObject.SetActive(true);
    }
    
    private void DehighlightEvOb()
    {
        interactEvObs[interactEvObs.Count - 1].transform.Find("HighlightSprite").gameObject.SetActive(false);
        transform.Find("ButtonPopup").gameObject.SetActive(false);
        //targetOb.transform.Find("HighlightSprite").gameObject.SetActive(false);
    }
}
