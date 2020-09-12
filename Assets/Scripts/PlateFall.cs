using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateFall : MonoBehaviour
{
    private float gravity;
    private static PlayerHealth playerHealth;
   
    private Rigidbody2D myRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        gravity = myRigidbody.gravityScale;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //让下方触发器调用设置
    public void setGravity(float g) {
        myRigidbody.gravityScale = g;
    }

    //杀死玩家或怪物
    private void OnCollisionEnter2D(Collision2D collision) {
        //玩家
       
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D") {
            Debug.Log("掉落撞到玩家");
            playerHealth.DamegePlayer(100);
        }else if (collision.gameObject.CompareTag("Enemy")) {
            EnemyMonster enemy = (EnemyMonster)collision.gameObject.GetComponentInParent<EnemyMonster>();
            enemy.TakeDamage(50);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D") {
            Debug.Log("Trigger掉落撞到玩家");
            playerHealth.DamegePlayer(100);
        }
    }
}
