using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueTrigger : MonoBehaviour
{
    public bool playerEnter;
    private PlayerController player;
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
        //if (collision.gameObject.CompareTag("Player")) {
            //Debug.Log("进入范围");
        //}
    }

    private void OnTriggerStay2D(Collider2D collision) {
        //人物在雕塑的一定范围内
        if (collision.gameObject.CompareTag("Player")) {
            playerEnter = true;
            player.CanMoveStatue(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            playerEnter = false;
            player.CanMoveStatue(false);
            //Debug.Log("退出范围");
        }
    }
}
