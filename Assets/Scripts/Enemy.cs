using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    public float timeToDie; //死亡延迟
    //public int damageByRock;
    public GameObject AttackedEffect;   //被击打特效
    public GameObject floatPoint;
    public Vector3 EffectOffset;    //特效的位置偏移

    public Animator myAnim;    //动画组件

    private PlayerHealth playerHealth;
    private Vector3 noRotation = new Vector3(0,0,0);

    // Start is called before the first frame update
    public void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        myAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    public void Update()
    {
        if (health <= 0)
        {
            myAnim.SetTrigger("Die");
            Invoke("killEnemy", timeToDie);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        GameObject gb = Instantiate(floatPoint, transform.position, Quaternion.identity) as GameObject;
        gb.transform.GetChild(0).GetComponent<TextMesh>().text = damage.ToString();
        Instantiate(AttackedEffect, transform.position + EffectOffset, Quaternion.identity);
        //GameController.camShake.Shake();
    }

    void killEnemy() {
        Destroy(gameObject);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            //播放怪物攻击动画
            myAnim.SetTrigger("Attack");    //触发怪物攻击动画
            SoundManager.PlayHitByEnemy();  //播放声音

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
            

        } 
        //怪物撞击到石头会扣血
        
    }

    public static explicit operator Enemy(GameObject v) {
        throw new NotImplementedException();
    }
}
