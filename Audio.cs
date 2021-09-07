using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip[] aClips;
    public AudioSource myAudioSource;

     void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }
    
     void Update ()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Debug.Log("Touch > 0");
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if (Physics.Raycast(ray, out Hit))
            {
                Debug.Log("if1");
                var selection = Hit.transform;
                if (selection.CompareTag("Sphere1"))
                {
                    myAudioSource.clip = aClips[Random.Range(0, aClips.Length)];
                    myAudioSource.PlayOneShot (myAudioSource.clip);
                    Debug.Log("if2");
                }
            }
        }
    }
}
/*
    void OnMouseOver()
    {
     if (Input.GetMouseButtonDown(0))
        {
            myAudioSource.clip = aClips[Random.Range(0, aClips.Length)];
            myAudioSource.PlayOneShot (myAudioSource.clip);
        }
    }

    void OnMouseExit()
        {
    //      myAudioSource.Stop();
        }*/

