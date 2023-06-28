using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip uiButton;
    public AudioClip playerAttack;
    public AudioClip coin;
    public AudioClip traps;
    public AudioClip enemyAttack;
    public AudioClip finish;
    public AudioClip checkpoint;
    private AudioSource audio;

    private void Awake()
    {
        if (instance != null)
            Destroy(finish);
        else
            instance = this;

        audio = GetComponent<AudioSource>();


    }




    public void UIClickSfx()
    {
        GetComponent<AudioSource>().PlayOneShot(uiButton);
    }

    public void UIPlayerAttack()
    {
        GetComponent<AudioSource>().PlayOneShot(playerAttack);
    }

    public void UITraps()
    {
        GetComponent <AudioSource>().PlayOneShot(traps);
    }

    public void UIEnemyAttack()
    {
        GetComponent<AudioSource>().PlayOneShot(enemyAttack);
    }

    public void UIFinish()
    {
        GetComponent<AudioSource>().PlayOneShot(finish);
    }

    public void UICheckpoint()
    {
        GetComponent<AudioSource>().PlayOneShot(checkpoint);
    }

    public void UICoin()
    {
        GetComponent<AudioSource>().PlayOneShot(coin);
    }
}
