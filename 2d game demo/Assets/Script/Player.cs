using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("movement")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float speedWhileCrouch = 2f;
    private bool isFacingRight = true;

    [Header("Check Layer")]
    [SerializeField] public Transform groundCheck;
    [SerializeField] public LayerMask groundLayer;
    [SerializeField] public float groundCheckDistance;

    [Header("Component")]
    public Rigidbody2D rb;
    public Animator anim;
    public BoxCollider2D box;

    
    public PlayerStateMachine StateMachine {  get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; } 
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerCrouchState crouchState { get; private set; }

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        

        idleState = new PlayerIdleState(this, StateMachine, "idle");
        moveState = new PlayerMoveState(this, StateMachine, "move");
        jumpState = new PlayerJumpState(this, StateMachine, "onAir");
        airState = new PlayerAirState(this, StateMachine, "onAir");
        crouchState = new PlayerCrouchState(this, StateMachine, "crouch");
        
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();

        StateMachine.Initialize(idleState);
    }

    // Update is called once per frame
    void Update()
    { 
        StateMachine.currentState.Update();

        if (IsGround())
        {
            Debug.Log("is on ground");
        }
    }

    public void Move(float xInput)
    {
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);
    }

    public void MoveWhileCrouch(float xInput)
    {
        rb.velocity = new Vector2(xInput * speedWhileCrouch, rb.velocity.y);
    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    public bool IsGround()
    {
        return Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);
    }

   public void Flip(float xInput)
    {
        if((isFacingRight && xInput < 0) || (!isFacingRight && xInput > 0))
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0, 180f, 0);
        }
    }
}
