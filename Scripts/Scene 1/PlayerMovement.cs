using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    private float direction;
    [SerializeField] private float speed; // serialize field untuk rubah angka langsung di inspector unity

    private bool grounded;
    public bool Jump2;

    // Start is called before the first frame update
    void Start()
    {
        //Ambil reference dari Rigidbody dan Animator
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        transform.localScale = new Vector3(-1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal adalah input arrows kanan dan kiri pada unity
        float horizontalInput = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed , body.velocity.y); //.y artinya yang berubah arah geraknya sumbu x

        //Untuk merubah arah hadap dari character ketika berubah arah
        if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);        
        }

        else if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            jump();
            
        }

        //Untuk Set Animator
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
        //anim.SetBool("Jump2", Jump2);
    }

    private void jump()
    {
         body.velocity = new Vector2(body.velocity.x, speed) ;//.x artinya yang berubah arah geraknya sumbu y
         //anim.SetBool("Jump2", Jump2);
         anim.SetTrigger("jump"); // jump itu
         grounded = false;
         //Jump2 = true;
    }

    private void OnCollisionEnter2D(Collision2D collision) // untuk ngecek apakah player nempel di ground atau tidak
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            //Jump2 = false;
        }
    }

   
}
