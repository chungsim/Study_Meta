using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public int weaponDamage;

    public PlayerBattleController playerBattleController;

    void Start()
    {
        if(weaponDamage == null)
        {
            Debug.Log($"{this.gameObject.name} weapon has no damage!");
            weaponDamage = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && 
        playerBattleController.isAttacking)
        {
            //플레이어 데미지 함수 처리
            collision.gameObject.GetComponent<PlayerBattleController>().GetDamage(weaponDamage);
        }
    }
}
