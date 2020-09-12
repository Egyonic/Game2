using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateMove : MonoBehaviour
{
    public float fallSpeed;
    public Transform fallPlateTrans;
    private Rigidbody2D rigidbody2D;
    //private Vector3 move;
    private PlateFall plateFall;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        //move = new Vector2(0, speedY);
        plateFall = fallPlateTrans.GetComponent<PlateFall>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        //Debug.Log("速度"+speedY);
        //Vector3 dest = transform.position + move * Time.deltaTime;
        //rigidbody2D.MovePosition(dest);
        //if (dest.y < maxY && dest.y > minY) {
        //    rigidbody2D.MovePosition(transform.position + move * Time.deltaTime);
        //}
        //else {
         //   Debug.Log("到达限制区域");
        //}
       
    }


    private void OnTriggerExit2D(Collider2D collision) {
        //Debug.Log("玩家离开了机关");
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D") {
            //speedY = 1.0f;
            plateFall.setGravity(fallSpeed * -1.0f);
            Debug.Log("玩家离开了机关");
            //Debug.Log("玩家胶囊碰撞体");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D") {
            //speedY = -1.0f;
            plateFall.setGravity(fallSpeed*1.0f);
            Debug.Log("玩家进入机关");
            //Debug.Log("玩家胶囊碰撞体");
        }
    }

}
