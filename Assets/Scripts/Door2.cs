using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour
{
    public bool set;
    public int statueID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //鸟的进入和离开
        if (collision.gameObject.CompareTag("Statue")) {
            StatueControl statue = collision.gameObject.GetComponent<StatueControl>();
            if (statue.StatueId == statueID) {
                set = true;
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Statue")) {
            StatueControl statue = collision.gameObject.GetComponent<StatueControl>();
            if (statue.StatueId == statueID) {
                set = false;
            }
        }
    }
}
