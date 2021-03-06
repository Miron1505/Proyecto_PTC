using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnColide : MonoBehaviour
{
    public string tagToColliderWith = string.Empty;

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag(tagToColliderWith))
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
