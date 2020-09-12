using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    public int damageByRock;

    public Animator myAnim;    //动画组件

    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    public void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        myAnim = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    public void Update()
    {
        if (health <= 0)
        {  
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
       
        health -= damage;

        //GameController.camShake.Shake();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            //翻转效果
            if (other.gameObject.transform.position.x < transform.position.x) {
                transform.localRotation = Quaternion.Euler(0, 180, 0);

            }
            else {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if (playerHealth != null)
            {
                playerHealth.DamegePlayer(damage);
            }
            //播放怪物攻击动画
            myAnim.SetTrigger("Attack");    //触发怪物攻击动画
            SoundManager.PlayHitByEnemy();  //播放声音

        } 
        //怪物撞击到石头会扣血
        else if (other.gameObject.CompareTag("RockBlock")) {
            TakeDamage(damageByRock);
        }
    }

    public static explicit operator Enemy(GameObject v) {
        throw new NotImplementedException();
    }
}
