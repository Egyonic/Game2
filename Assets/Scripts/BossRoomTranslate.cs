using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomTranslate : MonoBehaviour
{
    public bool isSet;  //对应的雕像是否已经放在上方
    public Transform destination; //要传送到的位置
    // Start is called before the first frame update
    void Start()
    {
        isSet = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Statue")) {
            if(other.gameObject.GetComponent<StatueControl>().StatueId == 4) {
                isSet = true;
            }
        }

        // 传送玩家到BOSS房间
        if (other.CompareTag("Player") && isSet) {
            other.GetComponentInParent<Transform>().position = destination.position;
            SoundManager.PlayPlayerTranslate();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Statue")) {
            if (other.gameObject.GetComponent<StatueControl>().StatueId == 4) {
                isSet = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        
    }
}
