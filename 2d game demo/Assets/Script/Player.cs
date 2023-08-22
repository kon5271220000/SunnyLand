using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("movement")]
    public float horizontalDirection;

    [Header("Component")]
    public Rigidbody2D rb;
    public Animator anim;

    
    public PlayerStateMachine StateMachine {  get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; } 

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        

        idleState = new PlayerIdleState(this, StateMachine, "idle");
        moveState = new PlayerMoveState(this, StateMachine, "move");
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        StateMachine.Initialize(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        Move(horizontalDirection);

        
    }

    private void GetInput()
    {
        horizontalDirection = Input.GetAxisRaw("Horizontal");
    }

    private void Move(float horizontalDirection)
    {
        rb.velocity = new Vector2(horizontalDirection * 5, rb.velocity.y);
    }
}
