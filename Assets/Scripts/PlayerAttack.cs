using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage;
    public float startTime;
    public float time;

    private Animator anim;
    private PolygonCollider2D collider2D;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>();
        collider2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if(Input.GetButtonDown("Attack"))
        {
            anim.SetTrigger("Attack");
            StartCoroutine(StartAttack());
        }
    }

    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(startTime);
        collider2D.enabled = true;
        StartCoroutine(disableHitBox());
    }

    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        collider2D.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("碰到怪物");
        if (other.gameObject.CompareTag("Enemy"))
        {
            Transform t = other.gameObject.GetComponentInParent<Transform>();
            
            //if(other.gameObject.transform.position.x > transform.position.x) {
            //    t.localRotation = Quaternion.Euler(0, 180, 0);
            //    
            //}
            //else {
            //    t.localRotation = Quaternion.Euler(0, 0, 0);
            //}
            other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Debug.Log("攻击了怪物");
        }
    }
}
