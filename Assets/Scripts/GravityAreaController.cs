using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 用于控制一个区域内的模拟改变重力和移动的效果
     */

public class GravityAreaController : MonoBehaviour
{
    public float speedX;
    public float speedY;
    public Vector2 direction;   //控制区域内的移动方向

    public static Item currentItem; //玩家当前的道具

    // 4个方向向量
    public static Vector2 upDir = new Vector2(0, 1);
    public static Vector2 downDir = new Vector2(0, -1);
    public static Vector2 leftDir = new Vector2(-1, 0);
    public static Vector2 rightDir = new Vector2(1, 0);
    public static Vector2 noDir = new Vector2(0,0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getSpeedX() {
        return speedX * direction.x;
    }

    public float getSpeedY() {
        return speedY * direction.y;
    }

    // 改变区域内的移动方向
    public void changeDirection(Vector2 dir) {
        direction = dir;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            Debug.Log("玩家进入有效范围");
        }
    }

    // 玩家进入了有效的可以使用重力石来操作的区域
    private void OnTriggerStay2D(Collider2D other) {
        // 判断进入触发区的是否是玩家
        if (other.CompareTag("Player")) {
            //Debug.Log("玩家进入有效范围");
            // 判断玩家是否使用了重力石头且模式为操作环境物体
            if (currentItem.name == "重力石" && currentItem.status == false
                && currentItem.isUsing) {
                if (Input.GetButtonDown("stoneDirectionUp")) {
                    Debug.Log("stoneDirectionUp");
                    direction = upDir;
                }
                else if (Input.GetButtonDown("stoneDirectionDown")) {
                    Debug.Log("stoneDirectionDown");
                    direction = downDir;
                }
                else if (Input.GetButtonDown("stoneDirectionLeft")) {
                    direction = leftDir;
                }
                else if (Input.GetButtonDown("stoneDirectionRight")) {
                    direction = rightDir;
                }
            }else
            {
                //if (!(currentItem.name == "重力石") || !currentItem.isUsing || currentItem.status == true
                //没有在使用
                direction = noDir;
            }
        }

       
    }

}
