using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int healValue;   //回复药水一次的回复值
    public int blinks;
    public float time;
    public float dieTime;
    public float hitBoxCdTime;

    private int maxHealth;  //记录最大生命值
    private Renderer myRender;
    private Animator anim;
    //private ScreenFlash sf;
    private Rigidbody2D rb2d;
    private PolygonCollider2D polygonCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        HealthBar.HealthMax = health;
        HealthBar.HealthCurrent = health;
        myRender = GetComponent<Renderer>();
        anim = GetComponent<Animator>();
        //sf = GetComponent<ScreenFlash>();
        rb2d = GetComponent<Rigidbody2D>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //回复生命的处理
    public void HealPlayer() {
        health += healValue;
        if(health > maxHealth) {
            health = maxHealth;
        }
        HealthBar.HealthCurrent = health;   //跟新UI
    }


    public void DamegePlayer(int damage)
    {
        //sf.FlashScreen();
        health -= damage;
        if(health < 0)
        {
            health = 0;
        }
        HealthBar.HealthCurrent = health;
        if (health <= 0)
        {
            rb2d.velocity = new Vector2(0, 0);
            //rb2d.gravityScale = 0.0f;
            GameController.isGameAlive = false;
            //anim.SetTrigger("Die");   播放死亡动画
            Invoke("KillPlayer", dieTime);
        }
        //BlinkPlayer(blinks, time);
        //polygonCollider2D.enabled = false;
        //StartCoroutine(ShowPlayerHitBox());
    }

    IEnumerator ShowPlayerHitBox()
    {
        yield return new WaitForSeconds(hitBoxCdTime);
        //polygonCollider2D.enabled = true;
    }

    void KillPlayer()
    {
        Destroy(gameObject);
    }

    void BlinkPlayer(int numBlinks, float seconds)
    {
        StartCoroutine(DoBlinks(numBlinks, seconds));
    }

    IEnumerator DoBlinks(int numBlinks, float seconds)
    {
        for(int i = 0; i < numBlinks * 2; i++)
        {
            myRender.enabled = !myRender.enabled;
            yield return new WaitForSeconds(seconds);
        }
        myRender.enabled = true;
    }
}
