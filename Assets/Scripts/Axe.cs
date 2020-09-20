using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;
    public int damage;
    public float tuning;

    private Rigidbody2D rb2d;
    private Transform playerTransform;
    private Transform axeTransform;
    private Vector2 startSpeed;
    private AxeHit axeHit;

    //private CameraShake camShake;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.right * speed;
        startSpeed = rb2d.velocity;
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        axeTransform = GetComponent<Transform>();

        axeHit = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<AxeHit>();
        //camShake = GameObject.FindGameObjectWithTag("CameraShake").GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed);
        float y = Mathf.Lerp(transform.position.y, playerTransform.position.y, tuning);
        transform.position = new Vector3(transform.position.x, y, 0.0f);
        rb2d.velocity = rb2d.velocity - startSpeed * Time.deltaTime;

        if (Mathf.Abs(transform.position.x - playerTransform.position.x) < 0.5f) {
            Destroy(gameObject);
            axeHit.addAxeAmount();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Enemy")) {
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
