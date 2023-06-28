using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Melee : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private float range;
    [SerializeField] private float distanceCollider;
    private float cooldownTimer = Mathf.Infinity;
    private Rigidbody2D rb;
    [SerializeField] private float speed;

    public float currentHealth { get; private set; }

    private Animator anim;
    private Health playerHealth;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        run();
    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetBool("Moving", false);
        cooldownTimer += Time.deltaTime;

        if (CheckPlayer())
        {
            if (cooldownTimer >= attackCooldown)
            {
                SoundManager.instance.UIEnemyAttack();
                //attack
                cooldownTimer = 0;

                anim.SetBool("Moving", false);

                //anim
                anim.SetTrigger("MeleeAttack");
                

            }
        }
        else
            anim.SetBool("Moving", true);
    }

    private void run()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);

    }

    private bool CheckPlayer()
    {
        //Cek posisi pemain
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * distanceCollider, 
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);

        

        if (hit.collider != null)
        
            playerHealth = hit.transform.GetComponent<Health>();
        
        return hit.collider != null;

    }

    //visualisasi area cek

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * distanceCollider,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if (CheckPlayer())
        {
            playerHealth.takeDamage(damage);
        }
    }
}
