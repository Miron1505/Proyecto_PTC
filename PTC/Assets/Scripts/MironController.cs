using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MironController : MonoBehaviour
{

    //Clase que toma dos valores.
    public enum FACE_DIRECTION
    {
        LEFT = -1,
        RIGHT = 1
    }

    public FACE_DIRECTION direction = FACE_DIRECTION.RIGHT;
    public static MironController Player;

    public bool canJump = true;
    public bool canMove = true;
    public bool isOnGround = false;

    public float jumpPower = 600;
    public float jumpTimeout = 1.0f;
    public float maxSpeed = 40.0f;

    // Tipos de movimiento
    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";
    public string jumpButton = "Jump";

    public Rigidbody2D rigidbody;
    public Transform transform;
    public BoxCollider2D feetCollider;
    public LayerMask groundLayer;

    public Transform BulletSpawner;
    public GameObject bulletPrefab;
    public float reloadDelay = 0.2f;
    public bool canFire = true;
    //public AudioSource ShootingSound;
    //public AudioSource JumpSound;

    public bool ShowGameOver = true;
    public Animator animator;

    public static float Health
    {
        get
        {
            return _health;
        }

        set
        {
            _health = value;

            if (_health <= 0)
            {
                if (Player.ShowGameOver) 
                {
                    //GameController.GameOver();
                }
            }
        }
    }

    [SerializeField]
    private static float _health = 100.0f;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        Player = this;
    }

    public void Jump ()
    {

        if (!isOnGround || !canJump) return;

        animator.SetBool("isJumping", true);

        //JumpSound.playOnAwake = true;
        //Instantiate(JumpSound);
        
        rigidbody.AddForce(Vector2.up * jumpPower);
        canJump = false;
        Invoke("EnableJump", jumpTimeout);

    }

    private void EnableJump()
    {
        canJump = true;
    }

    private void EnableFire()
    {
        canFire = true;
    }

    private bool GetGrounded ()
    {

        Vector2 boxCenter = new Vector2(transform.position.x, transform.position.y) + feetCollider.offset;
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(boxCenter, feetCollider.size, 0, groundLayer);

        if (hitColliders.Length > 0) return true; else return false;

    }

    private void ChangeDirection ()
    {
        direction = (FACE_DIRECTION)((int)direction * -1.0f);
        Vector3 localScale = transform.localScale;
        localScale.x *= -1.0f;
        transform.localScale = localScale;
    }

    void FixedUpdate()
    {
        if (!canMove || Health <= 0) return;

        isOnGround = GetGrounded();

        if(isOnGround == true) animator.SetBool("isJumping", false);

        float horizontal = CrossPlatformInputManager.GetAxis(horizontalAxis);
        //rigidbody.AddForce(Vector2.right * horizontal * maxSpeed);
        transform.position += Vector3.right * horizontal * maxSpeed;

        if ((horizontal < 0 && direction != FACE_DIRECTION.LEFT) || (horizontal > 0 && direction != FACE_DIRECTION.RIGHT)) 
        {
            ChangeDirection();
        }

        if (CrossPlatformInputManager.GetButton(jumpButton)) Jump();

        rigidbody.velocity = new Vector2
        (
            Mathf.Clamp(rigidbody.velocity.x, -maxSpeed, maxSpeed),
            Mathf.Clamp(rigidbody.velocity.y, - Mathf.Infinity, jumpPower)
        );

        if (Input.GetKeyDown(KeyCode.Z) && canFire)
        {
            animator.SetBool("isShooting", true);

            Instantiate(bulletPrefab, BulletSpawner.position, BulletSpawner.rotation);

            canFire = false;
            Invoke("EnableFire", reloadDelay);
            //ShootingSound.playOnAwake = true;
            //Instantiate(ShootingSound);
        }

    }

    private void OnDestroy()
    {
        Player = null;
    }

    public static void Die ()
    {
        Destroy(MironController.Player.gameObject);
    }

    public static void Reset ()
    {
        Health = 100.0f;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(horizontalAxis))
        {
            animator.SetBool("isRunning", true);
        }
        else if (Input.GetButtonUp(horizontalAxis))
        {
            animator.SetBool("isRunning", false);
        }

        if(canFire) animator.SetBool("isShooting", false);
    }
}
