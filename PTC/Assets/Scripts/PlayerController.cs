using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb2d;
    public SpriteRenderer sprite;

    public float jumpForce;
    private bool jump;
    private bool grounded;
    public GameObject groundCheck;
    public LayerMask whatIsGround;

    public AudioSource jumpSound;

    private Animator animador;
    private bool mirarDerecha;

    // Start is called before the first frame update
    void Start()
    {
        animador = GetComponent<Animator>();
        mirarDerecha = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (jump == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump = true;
            }
        }
    }

    void FixedUpdate ()
    {
        grounded = false;
        grounded = Physics2D.Linecast(transform.position, groundCheck.transform.position, whatIsGround);

        if(grounded && jump)
        {
            grounded = false;
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jumpSound.Play();
        }

        jump = false;

        float horizontal = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(horizontal*speed, rb2d.velocity.y);

        animador.SetFloat("VelMovimiento", Mathf.Abs (horizontal));

        if (horizontal > 0) sprite.flipX = false;
        if (horizontal < 0) sprite.flipX = true;
    }

}