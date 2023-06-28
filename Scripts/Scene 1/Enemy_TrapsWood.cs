using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_TrapsWood : MonoBehaviour
{
    [SerializeField] private float damage;
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    //private Animator anim;
    public SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();



    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
        //anim.SetTrigger("Active");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            SoundManager.instance.UITraps();
            collision.GetComponent<Health>().takeDamage(damage);
            
        }
    }



}
