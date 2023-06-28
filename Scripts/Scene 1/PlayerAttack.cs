using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCoolDown;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float coolDownTimer = Mathf.Infinity;

    //Untuk fire fireball
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;

    

    
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse1) && coolDownTimer > attackCoolDown) //Jika left click mouse dan syarat kedua agar tidak tembak terus menerus
        {
            Attack(); //Memanggil Function Attack
            
        }
        coolDownTimer += Time.deltaTime; // Supaya tidak terus menerus menembak
    }

    private void Attack()
    {
        SoundManager.instance.UIPlayerAttack();
        anim.SetTrigger("attack"); ;
        coolDownTimer = 0;
        

        //fireball
        fireballs[CheckFireball()].transform.position = firePoint.position;
        fireballs[CheckFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
        
    }

    private int CheckFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if(!fireballs[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

    
}
