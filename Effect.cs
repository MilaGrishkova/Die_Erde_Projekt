using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public GameObject EffectBoom1;
    public GameObject EffectBoom2;
    public GameObject EffectBoom3;
    
    void Update()
    {
       //if(Input.GetKey(KeyCode.Space)){
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Debug.Log("Touch > 0");
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if (Physics.Raycast(ray, out Hit))
            {
                Debug.Log("if1");
                var selection = Hit.transform;
                if (selection.CompareTag("Tag1")) 
                {
                    Instantiate(EffectBoom1, Vector3.zero, Quaternion.identity);
                    Instantiate(EffectBoom2, Vector3.zero, Quaternion.identity);
                    Instantiate(EffectBoom3, Vector3.zero, Quaternion.identity);
                }
           }
        }
    }
}
