using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    private Animator anim;

    public GameObject GameOverPanel;
    

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    takeDamage(1);
        //}
    }

    public void takeDamage(float _damage)
    {
        // Menentukan max dan min
        // min 0, max = health awal
        currentHealth = Mathf.Clamp(currentHealth -= _damage, 0, startingHealth); //Hasil dari pengurangan cur.health - damage, harus tidak lebih kecil dr 0 dan tidak lebih besar dari start health

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");

        }
        else
        {
            Time.timeScale = 1;
            anim.SetTrigger("die");
            GetComponent<PlayerMovement>().enabled = false;
            

            StartCoroutine(GameOverScene());

        }
       


        IEnumerator GameOverScene()
        {

            yield return new WaitForSeconds(2);
            GameOverPanel.SetActive(true);
            Time.timeScale = 0;
            
        }

       


    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

}
