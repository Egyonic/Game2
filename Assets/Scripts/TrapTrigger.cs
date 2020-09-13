using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public float fallSpeed;
    public Transform trap;
    private PlateFall plateFall;

    // Start is called before the first frame update
    void Start()
    {
        plateFall = trap.GetComponent<PlateFall>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
       
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
