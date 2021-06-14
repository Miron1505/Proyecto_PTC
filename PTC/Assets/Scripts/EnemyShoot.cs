using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float bulletSpeed;
    public float spawnTime;
    public GameObject spawner;
    public GameObject bulletPreFab;
    private float counter;



    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

        if(counter > spawnTime)
        {
            GameObject bullet = (GameObject)Instantiate(bulletPreFab, spawner.transform, true);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, bullet.GetComponent<Rigidbody2D>().velocity.y);
            counter = 0;
        }
    }
}
