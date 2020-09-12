using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMonster : Enemy
{
    public float speed;
    public float startWaitTime;
    private float waitTime;

    public Transform movePos;
    public Transform leftDownPos;
    public Transform rightUpPos;

    private bool Walk;
    private bool Idle;

    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        //myAnim.SetBool("Walk", true); //设置动画初始状态为行走
        waitTime = startWaitTime;
        movePos.position = GetRandomPos();
    }

    // Update is called once per frame
    public void Update()
    {
        //调用父类的Update()方法
        base.Update();
        getAnimState(); //获取动画状态值
        //Debug.Log("Walk"+myAnim.GetBool("Walk"));
        //Debug.Log("Idle" + myAnim.GetBool("Idle"));

        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);
        //myAnim.SetBool("IsWalk", true); //开始播放行走动画

        // 已经移动到了指定位置
        if (Vector2.Distance(transform.position, movePos.position) < 0.01f) {
            myAnim.SetBool("Walk", false);
            myAnim.SetBool("Idle", true);
            if (waitTime <= 0) {
                // 等待时间已经已经过了，前往下个位置
                //myAnim.SetBool("Walk", true);
                movePos.position = GetRandomPos();
                waitTime = startWaitTime;
            }
            else {
                // 还处于等待的状态
                waitTime -= Time.deltaTime;
                
            }
        }//还在移动的过程中
        else {
            myAnim.SetBool("Walk", true);
            myAnim.SetBool("Idle", false);
        }
    }

    Vector2 GetRandomPos() {
        Vector2 rndPos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x), Random.Range(leftDownPos.position.y, rightUpPos.position.y));
        return rndPos;
    }

    void getAnimState() {
        Walk = myAnim.GetBool("Walk");
        Idle = myAnim.GetBool("Idle");
    }
}
