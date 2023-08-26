using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float rangeAttack;
    private Transform target;
    private bool targetInAtkRange = false;
    private Vector3 firstPosition;

    private Rigidbody2D rb;
    private Animator anim;
    public EnemyHealth health;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();    
        health = GetComponent<EnemyHealth>();

        target = GameObject.FindGameObjectWithTag("Player").transform;
        firstPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scale = transform.localScale;
        float distanceFromPlayer = Vector2.Distance(target.position, transform.position);


        if (distanceFromPlayer < rangeAttack)
        {
            targetInAtkRange = true;
            anim.SetBool("isAttacking", targetInAtkRange);

            transform.position = Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);

            if(target.transform.position.x > transform.position.x)
            {
                scale.x = Mathf.Abs(scale.x) * -1;
            }
            else
            {
                scale.x = Mathf.Abs(scale.x);
            }

            transform.localScale = scale;
        }
        else
        {
            targetInAtkRange = false;
            anim.SetBool("isAttacking", targetInAtkRange);
            transform.position = Vector2.MoveTowards(this.transform.position, firstPosition, speed * Time.deltaTime);
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rangeAttack);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.gameObject.tag == "weapon")
        {
            health.TakeDamage(1);
        }
    }
}
