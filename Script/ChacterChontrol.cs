using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChacterChontrol : MonoBehaviour
{
    public float Speed; 
    public float jumpPower;
    public float extraJumps;
    int HasarVur=1;

    Rigidbody2D rb;
    [SerializeField] LayerMask groundLayers;
    [SerializeField] Transform Feet;
    Animator anim;

    int jumpCount = 0;
    bool isGrounded;
    float jumpCoolDown;
    float mx;

    //Yeni Dash
    bool isDashing;
    public float dashTime;
    public float dashSpeed;
    public float dashCoolDown;
    private float dashTimeLeft;
    private float lastDash = -100f;

    public  bool canMove = true;
    public int dashActive;
    public int MagmaMeyvesi;



    public int noOfClicks = 0;
    float lastClikTime = 0;
    float maxComboDelay = 1f;


    public Vector3 moveDirection;


    private void Start()
    {
        Cursor.visible = false;
        rb = GetComponent<Rigidbody2D>();
        extraJumps= PlayerPrefs.GetInt("DoubleJump");
        dashActive = PlayerPrefs.GetInt("DashActive");
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");


        if (mx > 0f)
        {
            transform.localScale = new Vector3(3f, 3f, 3f);
        }
        else if (mx < 0f)
        {
            transform.localScale = new Vector3(-3f, 3f, 3f);
        }


        if (Mathf.Abs(mx) > 0.02)
        {
            anim.SetBool("Run", true);
        }
        else
            anim.SetBool("Run", false);

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetButtonDown("Dash") && dashActive>0)
        {
            if (Time.time>=(lastDash+dashCoolDown))
            {
              AttempToDash();
            }
        }
        ChechDash();
        CheckGrounded();



        if (Time.time - lastClikTime > maxComboDelay)
        {
            noOfClicks = 0;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            lastClikTime = Time.time;
            noOfClicks++;
            if (noOfClicks == 1)
            {
                anim.SetBool("AttackOne", true);
            }
            noOfClicks = Mathf.Clamp(noOfClicks, 0, 5);
        }

    }

    public void return1()
    {
        if (noOfClicks>=2)
        {
            anim.SetBool("AttackTwo", true);
        }
        else
        {
            anim.SetBool("AttackOne", false);
            noOfClicks = 0;
        }
    }

    public void return2()
    {
        if (noOfClicks >= 3)
        {
            anim.SetBool("AttackThree", true);
        }
        else
        {
            anim.SetBool("AttackTwo", false);
            noOfClicks = 0;
        }
    }

    public void returun3()
    {
        anim.SetBool("AttackOne", false);
        anim.SetBool("AttackTwo", false);
        anim.SetBool("AttackThree", false);
        noOfClicks = 0;
    }




    void AttempToDash()
    {
        isDashing = true;
        dashTimeLeft = dashTime;
        lastDash = Time.time;
    }
    void ChechDash()
    {
        if (isDashing)
        {
            if (dashTimeLeft>0)
            {
                canMove = false;
                rb.velocity = new Vector2(dashSpeed * mx, rb.velocity.y);
                dashTimeLeft -= Time.deltaTime;
            }
            if (dashTimeLeft <= 0)
            {
                isDashing = false;
                canMove = true;
            }
        }
    }
    private void FixedUpdate()
    {
        if (canMove)
            rb.velocity = new Vector2(mx * Speed, rb.velocity.y);
    }
    void Jump()
    {
        if (isGrounded || jumpCount<extraJumps)
        {
             rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpCount++;
            anim.SetTrigger("Jump");
            anim.SetBool("Run", false);
            
        }
    }

    void CheckGrounded()
    {
        if (Physics2D.OverlapCircle(Feet.position, 0.5f, groundLayers)){
            isGrounded = true;
            jumpCount = 0;
            jumpCoolDown = Time.deltaTime + 0.2f;
        }else if (Time.time < jumpCoolDown)
        {
            isGrounded = true;}
        else
        {
            isGrounded = false;} 
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Enemy")
        {
            collision.GetComponent<EnemyHit>().Damage(HasarVur);
            //moveDirection = rb.transform.position - collision.transform.position;
            moveDirection = collision.transform.position - rb.transform.position;
            collision.GetComponent<EnemyHit>().Fırlat(moveDirection);
        }
    }
}
