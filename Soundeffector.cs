using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundeffector : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip Boom;
    
    public void PlayBoomSound()
    {
        audioSource.PlayOneShot(Boom);
    }
}
