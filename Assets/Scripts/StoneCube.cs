using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 玩家靠近后可以取得的小石头道具，用于开启机关
public class StoneCube : MonoBehaviour
{
    private PlayerController player;
    private bool playerIn;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("进入获取道具范围");
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("进入获取道具范围");
            if(Input.GetButtonDown("TakeItem")) {
                player.HaveDeviceItem = true;
                Destroy(gameObject);    //消除道具
            }
        }
    }
}
