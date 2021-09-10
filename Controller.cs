using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject Sphere1;
    public GameObject Sphere2;
    public GameObject ARCamera;
    public GameObject Target;
    public soundeffector soundeffector;
    public AudioSource myAudioSource;

    void Start()
    {
        Sphere2.gameObject.SetActive(false);
        myAudioSource = GetComponent<AudioSource>();
    }

    void Update()
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
                    Destroy(Sphere1);
                    soundeffector.PlayBoomSound();
                    Sphere2.gameObject.SetActive(true);
                    Sphere2.transform.position = Vector3.zero;
                    Target.GetComponent<AudioSource>().Play();
                    Invoke("AudioSourceDestr", 10f);
                }
            }
        }
    }
/*
    void Update()
        {
            if(Input.GetKey(KeyCode.Space))
                {
                    ARCamera.GetComponent.<soundeffector>().enabled = false;
                }       
        }
*/

        void AudioSourceDestr()
        {
            Destroy(myAudioSource);
        }
}
