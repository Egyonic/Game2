using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateTrigger : MonoBehaviour
{
    public Transform destination;   //传送的目的地位置
    public static Item spaceStone; //玩家在用空间石
    private bool lastStatus;
    //private Item spaceStone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //通过空间石的使用状态是否改变，来触发传送
    private void OnTriggerStay2D(Collider2D other) {
        //Debug.Log("进入传送区");
        if (other.CompareTag("Player")) {
            if (Input.GetButtonDown("UseStone")) {
                // 对自身使用
                if (spaceStone.status == true) {
                    Debug.Log("传送---");
                    other.GetComponentInParent<Transform>().position = destination.position;
                    SoundManager.PlayPlayerTranslate();
                }

            }
            // 判断对自身使用以及按下了使用键
            /*
            if (spaceStone.status == true && (spaceStone.isUsing!= lastStatus)) {
                // 先改变上次使用状态
                lastStatus = spaceStone.isUsing;
                Debug.Log("传送---");
                other.GetComponentInParent<Transform>().position = destination.position;
                //other.transform.position = destination.position;
                
            }
            */


        }
    }
}
