using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDevice : MonoBehaviour
{
    public bool isSet;  //机关是否启动了, 还可以用于判断是否将道具的图像显示在对应位置上
    public Transform stoneTarget;   // 要移动的目标
    public float speed; //被控制物体的移动速度


    private PlayerController player;
    private Rigidbody2D targetRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        targetRigidbody = stoneTarget.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    /*
     两种方案来实现机关启动移动石头的效果
     1. 启动和不启动时设置左右的移动速度，通过不可见的碰撞体来阻挡
     2. 设置速度，但是通过两个Postion记录极限位置，实现在一定位置停下
         */

    // Update is called once per frame
    void Update()
    {
        if (isSet) {
            targetRigidbody.velocity = Vector2.right;
        }
        else {
            targetRigidbody.velocity = Vector2.left;
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (Input.GetButtonDown("TakeItem")) {
            //拥有石头
            if (player.HaveDeviceItem) {
                if (!isSet) {
                    //石块向右移动
                    targetRigidbody.velocity = Vector2.right;
                    isSet = true;
                }
                else {
                    //石块向左移动
                    targetRigidbody.velocity = Vector2.left;
                    isSet = false;
                }
            }
           
        }
        
    }
}
