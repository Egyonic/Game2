using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public static Item gravityStone; //玩家的重力石道具
    // 两个自身的移动速度，将由管理模拟重力区域的父类来控制
    // 在值中通过正负值来控制方向
    private float speedX;  //  x速度
    private float speedY;  //  y速度

    private GravityAreaController gravityAreaController;
    private Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        gravityAreaController = transform.GetComponentInParent<GravityAreaController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gravityAreaController.speedX);
    }

    private void FixedUpdate() {
        if (gravityStone.isUsing && gravityStone.status == false) {
            syncSpeedAndDireaction();
            Vector3 move = new Vector2(speedX, speedY);
            //rigidbody2D.MovePosition(transform.position + move * Time.deltaTime);
            rigidbody2D.velocity = move;
        }
        

    }

    private void syncSpeedAndDireaction() {
        speedX = gravityAreaController.getSpeedX();
        speedY = gravityAreaController.getSpeedY();
    }


}
