using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public GameObject player;

    private Transform playerTrans;
    private Rigidbody2D bulletRB;

    public float bulletSpeed;
    public float damage = 100.0f;
    public float bulletLife;

    void Awake()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerTrans = player.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (playerTrans.localScale.x > 0)
        {
            bulletRB.velocity = new Vector2(bulletSpeed, bulletRB.velocity.y);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            bulletRB.velocity = new Vector2(-bulletSpeed, bulletRB.velocity.y);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player")) return;

        Health health = col.gameObject.GetComponent<Health>();

        if (health == null) return;

        health.healthPoints -= damage;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, bulletLife);
    }
}
