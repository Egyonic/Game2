using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueControl : MonoBehaviour
{
    // 雕像的ID，区分几种不同的雕像，
    public int StatueId;
    public Transform head;  //头部子对象
    public Transform trigger;   //用于检测玩家进入范围的对象
    public float headMoveY;
    public float moveSpeed; //被玩家控制时的移动速度

    private Rigidbody2D myRigidbody;
    private PlayerController player;
    private bool headIsMoved;   //头是否伸长
    private StatueTrigger statueTrigger; //范围控制的脚本类对象     
    private Vector3 moveVec;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        statueTrigger = trigger.GetComponent<StatueTrigger>();
        headIsMoved = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        moveVec = new Vector3(0.0f, headMoveY, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //玩家进入范围内的时候开启可以控制
        if (statueTrigger.playerEnter) {
            //player.CanMoveStatue(true); //设置玩家可以操控雕
            //监听玩家是否进入控制雕像的状态
            if (Input.GetButtonDown("MoveStatuteHead")) {
                changeHead();
            }
            if (player.isMovingStatue) {
                moveByPlayer();
            }
        }
        else if(!statueTrigger.playerEnter)
        {
            //player.CanMoveStatue(false); //设置玩家可以操控雕像
        }
    }

    //被人物控制移动
    void moveByPlayer() {
        float moveX = Input.GetAxis("Horizontal");
        Vector2 playerVel = new Vector2(moveX * moveSpeed, 0.0f);
        myRigidbody.velocity = playerVel;
    }

    //改变鸟的脖子长度
    void changeHead() {
        if(!headIsMoved)
            head.position = head.position + moveVec;
        else
            head.position = head.position - moveVec;
        headIsMoved = !headIsMoved;
    }
  
}
