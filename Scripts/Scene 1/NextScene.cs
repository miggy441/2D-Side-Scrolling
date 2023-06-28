using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
   

    // Start is called before the first frame update
    void Start()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SoundManager.instance.UICheckpoint();
            StartCoroutine(ChangeScene());
        }
    }


    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(true);
        SceneManager.LoadScene("Level2");

        
    }

    
}
