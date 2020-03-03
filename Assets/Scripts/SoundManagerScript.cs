using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip playerHitSound, fireSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerHitSound = Resources.Load<AudioClip>("playerHit");
        fireSound = Resources.Load<AudioClip>("fire");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip) {
            case "fire":
                audioSrc.PlayOneShot(fireSound);
                break;
            case "playerHit":
                audioSrc.PlayOneShot(playerHitSound);
                break;
        }
    }
}
