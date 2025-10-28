using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCustomManager : MonoBehaviour
{
    public List<Animation> petList;
    public List<Sprite> ItemList;

    public List<Sprite> RideList;

    private GameObject player;

    public static PlayerCustomManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        player = GameObject.Find("Player");
        Debug.Log(PlayerPrefs.GetInt("ItemNum", 0));
        SetPet(PlayerPrefs.GetInt("PetNum", 0));
        SetItem(ItemList[PlayerPrefs.GetInt("ItemNum", 0)], PlayerPrefs.GetInt("ItemNum", 0));
    }

    public void SetPet(int i)
    {
        Animator anim = player.transform.Find("CustomPet").GetComponent<Animator>();
        anim.SetInteger("PetNum", i);
        PlayerPrefs.SetInt("PetNum", i);
    }

    public void SetItem(Sprite sprite, int i)
    {
        PlayerPrefs.SetInt("ItemNum", i);
        player.transform.Find("CustomItem").GetComponent<SpriteRenderer>().sprite = sprite;
    }

    public void SetRide(int i)
    {
        PlayerPrefs.SetInt("ItemNum", i);
        player.transform.Find("CustomRide").GetComponent<SpriteRenderer>().sprite = RideList[i];
    }
    
}
