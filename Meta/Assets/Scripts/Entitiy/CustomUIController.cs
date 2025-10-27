using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class CustomUIController : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image itemPre;
    [SerializeField] private UnityEngine.UI.Image petPre;

    public List<Sprite> itemList;
    public List<Sprite> petList;

    private int itemNum;
    private int petNum;

    public void SetItemImage(int i)
    {
        itemPre.sprite = itemList[i];
        itemNum = i;
    }

    public void SetPetImage(int i)
    {
        petPre.sprite = petList[i];
        petNum = i;
    }
    
    public void ApplyCustom(int i)
    {
        PlayerCustomManager.Instance.SetPet(petNum);
        PlayerCustomManager.Instance.SetItem(itemList[itemNum], itemNum);
    }
}
