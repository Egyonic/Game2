using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private float gravity;
    private Rigidbody2D myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        gravity = myRigidbody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //用于给控制器设置门的重力来移动门
    public void setGravity(float g) {
        myRigidbody.gravityScale = g;
    }
}
