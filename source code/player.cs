using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    private Rigidbody2D rb;
    private float xInput;
    [SerializeField]private float moveSpeed;
    [SerializeField]private float jumpForce;

    [SerializeField]private Animator anim;
    private bool isMove;

    private int facingDir = 1;//面朝方向
    private bool facingRight = true;//是否面朝右

    [SerializeField]private float groundCheckDistance;
    private bool isGround;
    [SerializeField]private LayerMask whatIsGround;//地面判定

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //检测所有组件，如果有刚体则将rb分配给它。
        anim = GetComponentInChildren<Animator>();
        moveSpeed = 5;
        jumpForce = 7.5f;
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xInput * moveSpeed , rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && isGround){
            rb.velocity = new Vector2(rb.velocity.x , jumpForce);  
        }

        if (Input.GetKeyDown(KeyCode.R)){
            Filp();
        }

        isGround = Physics2D.Raycast(transform.position,Vector2.down,groundCheckDistance,whatIsGround);//Raycast:(起点，方向，长度，层)

        FilpController();
        AnimatorController();

    }

    private void AnimatorController(){
        isMove = rb.velocity.x != 0;
        anim.SetFloat("yVelocity",rb.velocity.y);
        anim.SetBool("isMove", isMove);
        anim.SetBool("isGround",isGround);

    }
    private void Filp(){
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0,180,0);
    }
    private void FilpController(){
        if(rb.velocity.x > 0 && !facingRight){
            Filp();
        }
        else if (rb.velocity.x < 0 && facingRight){
            Filp();
        }
    }

    private void OnDrawGizmos(){
        Gizmos.DrawLine(transform.position,new Vector3(transform.position.x , transform.position.y - groundCheckDistance));

    }
}
