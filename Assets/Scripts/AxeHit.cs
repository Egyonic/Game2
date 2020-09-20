using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeHit : MonoBehaviour
{
    public GameObject axe;
    public int axeAmount;
    public float startTime; //延迟的时间，配合动画

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Attack") && axeAmount>0) {
            anim.SetTrigger("Attack");
            StartCoroutine(onceAttack());
        }
    }

    IEnumerator onceAttack() {
        yield return new WaitForSeconds(startTime);
        Instantiate(axe, transform.position, transform.rotation);
        axeAmount--;    //可用数量减少1
    }

    public void addAxeAmount() {
        axeAmount++;
    }


}
