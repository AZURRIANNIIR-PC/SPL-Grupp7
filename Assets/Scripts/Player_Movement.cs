
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private Transform groundCheck; //Kollar om spelaren är på marken eller inte
    [SerializeField] private LayerMask groundMask; //Vad tolkas som mark?
    private Rigidbody2D rigidBody2D;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private bool isFacingRight = true;

    //attackera
    //private GameObject AttackArea = default;
    private AttackArea attackArea;
    public bool attacking = false;
    private float timeToAttack = 0.73f;
    private float timer = 0;

    // Start is called before the first frame update
    private void Start() {
        rb = GetComponent<Rigidbody2D>(); //Hämtar referens till spelarens rigidbody
        animator = GetComponent<Animator>();
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();

        //AttackArea = transform.GetChild(0).gameObject;
        attackArea = gameObject.GetComponentInChildren<AttackArea>();
        attackArea.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundMask); //Kollar om spelaren är på marken

        //Spelarens rörelse
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        //Hopp
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        //Vänd spelarens sprite baserat på rörelseriktningen
        if (moveInput > 0 && !isFacingRight) {
            Flip();
        } else if (moveInput < 0 && isFacingRight){
            Flip();
        }

        //Attackera
        if (Input.GetKeyDown(KeyCode.Return)) //return = enter //|| Input.GetMouseButtonDown(0)
        {
            Attack();
        }

        if (attacking == true)
        {
            timer += Time.deltaTime;
            if(timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.gameObject.SetActive(attacking);
            }

        }
    }

    private void Flip() { //Vänder på spelarens sprite
        isFacingRight = !isFacingRight; //Byt riktning
        Vector3 scale = transform.localScale;
        scale.x *= -1; //Inverterar x-skalan för att vända sprite horisontellt
        transform.localScale = scale;
    }

    private void Attack()
    {
        attacking = true;
        animator.SetTrigger("DoAttack"); //sätter igång animationen - är en trigger, inte en bool etc
        Invoke("enableAttackArea", 0.3f);
    }

    public void enableAttackArea()
    {
        attackArea.gameObject.SetActive(attacking);
        //enablear attack area efter en liten stund så det timear med att animation hinner tr�ffa fienden
    }

    public bool IsFalling() {
        if (rigidBody2D.velocity.y < -1f) {
            return true;
        }
        return false;
    }
}
