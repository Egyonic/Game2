using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float fallSpeed;
    public Transform DoorTransform;    //目标对象
    private Door door;    //控制脚本组件

    // Start is called before the first frame update
    void Start() {
        door = DoorTransform.GetComponent<Door>();
    }

    // Update is called once per frame
    void Update() {

    }

    private void FixedUpdate() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //改成鸟的进入和离开
        if (collision.gameObject.CompareTag("Statute")) {
            door.setGravity(fallSpeed * -1.0f);
            Debug.Log("启动门开关");
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        //改成鸟的进入和离开
        if (collision.gameObject.CompareTag("Statute")) {
            door.setGravity(fallSpeed * 1.0f);
            Debug.Log("关闭开关");
        }
    }

    
}
