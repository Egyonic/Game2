using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioSource audioSrc;
    public static AudioClip playerAttack;
    public static AudioClip switchItem;
    public static AudioClip playerTranslate;
    public static AudioClip hitByEnemy;
    public static AudioClip addBlood;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        switchItem = Resources.Load<AudioClip>("SwitchItem");
        playerTranslate = Resources.Load<AudioClip>("TranslateAudio");
        hitByEnemy = Resources.Load<AudioClip>("HitByEnemy");
        addBlood = Resources.Load<AudioClip>("AddBlood");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySwitchItem()
    {
        audioSrc.PlayOneShot(switchItem);
    }

    public static void PlayPlayerTranslate() {
        audioSrc.PlayOneShot(playerTranslate);
    }
    public static void PlayHitByEnemy() {
        audioSrc.PlayOneShot(hitByEnemy);
    }
    public static void PlayAddBlood() {
        audioSrc.PlayOneShot(addBlood);
    }

}
