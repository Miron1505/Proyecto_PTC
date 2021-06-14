using UnityEngine;
using System.Collections;

public class PingPongMovement : MonoBehaviour
{
    private Transform theTransform = null;
    private Vector3 originPosition = Vector3.zero;
    public Vector3 moveDirection = Vector3.zero;

    public float distance = 3.0f;//la distancia hasta donde se mueve
    public float velocidad = 1;

    void Awake()
    {
        theTransform = GetComponent<Transform>();//
        originPosition = theTransform.position;
    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        theTransform.position = originPosition + moveDirection * Mathf.PingPong(velocidad * Time.time, distance);//movimiento
    }
}