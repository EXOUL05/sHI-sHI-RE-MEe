using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float movement;
    public float moveSpeed;
    public float jumpValue;
    public Rigidbody2D rb;

    //Flip
    bool isFacingRight;
    bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    //Jump Smoother
    public float timeToJump;
    private float jumpTimer;

    //Animation
    private Animator anim;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {   //grouncheck
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);  
        //Jump input

        

        if(isGrounded)
        {
            jumpTimer = timeToJump;
        }
        else{

            jumpTimer -= Time.deltaTime;
        }
                

        if (Input.GetKeyDown(KeyCode.Space) && jumpTimer > 0)
        {
         
            rb.velocity = Vector2.up * jumpValue * Time.deltaTime;

            
        }

    }
    private void FixedUpdate()
    { 
        //Movement
        movement = Input.GetAxisRaw("Horizontal");
        if(movement != 0)
        {
            //Animation Here
            anim.SetBool("isWalking", true);

        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        if(isFacingRight == false && movement < 0)
        {
            Flip();

        }
        else if(isFacingRight == true && movement > 0)
        {
            Flip();
        }
        rb.velocity = new Vector2(movement * moveSpeed, rb.velocity.y);
        
    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;

    }
}
