using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBat : Enemy {
    public float speed;
    public float startWaitTime; //动作间的间隔时间
    private float waitTime;

    public Transform movePos;
    public Transform leftDownPos;   //左右移动范围
    public Transform rightUpPos;

    private bool Walk;
    private bool Idle;

    // Start is called before the first frame update
    public void Start() {
        base.Start();
        //myAnim.SetBool("Walk", true); //设置动画初始状态为行走
        waitTime = startWaitTime;
        movePos.position = GetRandomPos();
    }

    // Update is called once per frame
    public void Update() {
        //调用父类的Update()方法
        base.Update();
        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);
        // 已经移动到了指定位置
        if (Vector2.Distance(transform.position, movePos.position) < 0.01f) {
            //myAnim.SetBool("Walk", false);
            //myAnim.SetBool("Idle", true);
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
            //myAnim.SetBool("Walk", true);
            //myAnim.SetBool("Idle", false);
        }
    }

    Vector2 GetRandomPos() {
        Vector2 rndPos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x), Random.Range(leftDownPos.position.y, rightUpPos.position.y));
        return rndPos;
    }

}
