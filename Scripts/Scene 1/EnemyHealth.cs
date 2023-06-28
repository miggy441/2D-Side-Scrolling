using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float enemystartingHealth;
    private Animator anim;
    public float enemycurrentHealth { get; private set; }
    [SerializeField] private int damage;
    public GameObject enemy;


    // Start is called before the first frame update
    void Start()
    {
        enemycurrentHealth = enemystartingHealth;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(float _damage)
    {
        // Menentukan max dan min
        // min 0, max = health awal
        enemycurrentHealth = Mathf.Clamp(enemycurrentHealth -= _damage, 0, enemystartingHealth); //Hasil dari pengurangan cur.health - damage, harus tidak lebih kecil dr 0 dan tidak lebih besar dari start health

        if (enemycurrentHealth > 0)
        {
            anim.SetTrigger("Hurt");
            
        }
        else
        {
            anim.SetTrigger("Die");
            GetComponent<Enemy_Melee>().enabled = false;
            
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fireball")
        {
            collision.GetComponent<EnemyHealth>().takeDamage(damage);
        }
    }
}
