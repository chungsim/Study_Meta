using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBattleController : MonoBehaviour
{
    public GameObject weaponPivot;
    public SpriteRenderer charactetRenderer;

    public float attackCooldown = 0.05f;

    public bool isAttacking = false;
    public float attackPerSec = 1.0f;

    private Quaternion baseQuaternion;

    public int hp = 10;
    public int maxHp = 10;
    public Sprite hpForward;

    public KeyCode keyCode;

    public BaseController playerController;

    void Start()
    {
        if(weaponPivot == null)
        {
            Debug.LogError("No Weapon Matched");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyCode) && attackCooldown <= 0 && !isAttacking && ColosseumGameManager.Instance.isGaming)
        {
            StartCoroutine(AttackAction());
        }
        else if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
            if (attackCooldown <= 0)
            {
                attackCooldown = 0;
            }
            weaponPivot.transform.rotation = baseQuaternion;
        }
        else
        {
            weaponPivot.transform.rotation = baseQuaternion;
        }

    }
    void FixedUpdate()
    {
        if (!isAttacking)
        {
            if (charactetRenderer.flipX == false)
            {
                baseQuaternion = Quaternion.Euler(0f, 0f, 0f);
            }
            else
            {
                baseQuaternion = Quaternion.Euler(0f, 0, 180f);
            }
        }
           
    }

    IEnumerator AttackAction()
    {
        float time = 0f;
        isAttacking = true;
        //Debug.Log("attack Coroutine");

        while (time < (1 / attackPerSec))
        {
            float rotateZ = -360f * (time * attackPerSec) + (baseQuaternion.z > 0 ? 180f : 0f);
            weaponPivot.transform.rotation = Quaternion.Euler(0, 0, rotateZ);
            time += Time.deltaTime;
            yield return null;
        }

        isAttacking = false;
        attackCooldown = 0.1f;

    }
    
    public void GetDamage(int damage)
    {
        hp -= damage;
        if (hp < 0) hp = 0;
        ColosseumUIManager.Instance.UpdateHPBar();
        Debug.Log($"player get {damage} damage! remain hp = {hp}");

        if (hp <= 0)
        {
            hp = 0;
            ColosseumGameManager.Instance.EndGame();
        }
    }
}
