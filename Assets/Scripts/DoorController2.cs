using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController2 : MonoBehaviour
{
    public float fallSpeed;
    public Transform DoorTransform;    //目标对象
    public Door2 trigger1;
    public Door2 trigger2;

    private Door door;    //控制脚本组件

    // Start is called before the first frame update
    void Start() {
        door = DoorTransform.GetComponent<Door>();
    }

    // Update is called once per frame
    void Update() {
        if(trigger1.set && trigger2.set) {
            door.setGravity(fallSpeed * -1.0f);
           
        }
        else {
            door.setGravity(fallSpeed * 1.0f);
            
        }
    }
   
}
