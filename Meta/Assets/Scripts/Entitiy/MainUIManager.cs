using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIManager : MonoBehaviour
{
    //UI List
    [SerializeField] private List<GameObject> UIPanelList;

    // UI Stack
    [SerializeField] private List<GameObject> UIStack;

    public void PopupUI(int i)
    {
        if (i < UIPanelList.Count)
        {
            UIStack.Add(UIPanelList[i]);
            UIPanelList[i].SetActive(true);

            FullUICheck();
        }
        else
        {
            Debug.LogError("Index Unmatch_MAinUIManager_UIPanelList");
        }
    }
    
    private void FullUICheck()
    {
        if(UIStack[UIStack.Count -1].GetComponent<UIInfos>().Type == UIType.Full)
        {
            if(UIStack.Count > 1)
            {
               for(int i = UIStack.Count -2; i >= 0; i--)
                {
                    if(UIStack[UIStack.Count -1].GetComponent<UIInfos>().Type == UIType.Full)
                    {
                        UIStack[i].SetActive(false);
                        UIStack.Remove(UIStack[i]);
                    }
                } 
            }       
        }
    }


}
