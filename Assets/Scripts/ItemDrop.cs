using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public Transform target;

    private BoxCollider2D boxCollider2D;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null) {
            this.transform.position = target.position;
        }
        else {
            boxCollider2D.enabled = true;
            spriteRenderer.enabled = true;
        }
    }
}
