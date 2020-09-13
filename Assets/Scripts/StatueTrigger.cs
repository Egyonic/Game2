using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueTrigger : MonoBehaviour
{
    public bool playerEnter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision) {
        //人物在雕塑的一定范围内
        if (collision.gameObject.CompareTag("Player")) {
            playerEnter = true;
            Debug.Log("玩家进入了范围");
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            playerEnter = false;
            Debug.Log("退出范围");
        }
    }
}
