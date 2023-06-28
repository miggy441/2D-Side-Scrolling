using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private Rigidbody2D rb;
    //public GameObject gameObject;
    public GameplayManager gameplayManager;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SoundManager.instance.UIFinish();
            StartCoroutine(EndGame());
        }
    }


    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2);
        gameplayManager.GameOver();



    }
}
