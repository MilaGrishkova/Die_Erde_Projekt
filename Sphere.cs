using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere: MonoBehaviour
{ 
    public AudioClip[] aClips;
    public AudioSource myAudioSource;
    public GameObject Sphere3;
  
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        this.SphereFormation(30, 1, 30);
    }


    void Update ()
    { 
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)        
        {   
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if (Physics.Raycast(ray, out Hit))
             {
                var selection = Hit.transform;
                if (selection.CompareTag("Tag"))
                 {
                     myAudioSource.clip = aClips[Random.Range(0, aClips.Length)];
                     myAudioSource.PlayOneShot (myAudioSource.clip);
                 }    
             }
         } 
     }

    //https://www.youtube.com/watch?v=te024cfBy8k
   
    private List<GameObject> HalfCircleFormation(int numberOfPoints, int radius)
    {
        int pieces = numberOfPoints;

        // Reference to the list of spheres that will be created for the half circle.
        List<GameObject> spheres = new List<GameObject>();

        // Set a container variable that is used to hold child objects in the inspector.
        GameObject container = new GameObject("SphereContainer");
        // Set the position to 0.
        container.transform.position = Vector3.zero;

        // Loop through the numberOfPoints that are in the half circle.
        for(int i = 0; i < numberOfPoints; i++)
        {
            // Instantiate the prefab.
            GameObject instance = Instantiate(Sphere3);

            // Get the angle of the current index being instantiated
            // from the center.
            // Mathf.PI represents half a circle.
            float theta = Mathf.PI * i / pieces;
            // Get the X Position of the theta angle times 1.5f. 1.5f is the radius.
            float X = Mathf.Cos(theta) * radius;
            // Get the Y Position of the theta angle times 1.5f. 1.5f is the radius.
            float Y = Mathf.Sin(theta) * radius;

            // Set the instantiated gameObjects position to a new Vector3 with the new variables.
            instance.transform.position = new Vector3(X, Y, 0);
            // Set the gameObjects color to green.
           // instance.GetComponent<MeshRenderer>().material.color = Color.green;
            // Set the instantiated object as a child of the container gameObject.
            instance.transform.SetParent(container.transform);
            // Add the instance to the list.
            spheres.Add(instance);
        }
        // Return the half circle that was created.
        return spheres;
    }

    /// <summary>
    /// The SphereFormation function.
    /// Creates a Sphere Formation.
    /// </summary>
    /// <param name="numberOfPoints">The numberOfPoints in the sphere.</param>
    /// <param name="radius">The radius of the sphere.</param>
    /// <param name="numberOfMeridians">The number numberOfMeridians in the sphere.</param>
    private void SphereFormation(int numberOfPoints, int radius, int numberOfMeridians)
    {
        // Create a Half Circle Formation and return the list of gameObjects.
        List<GameObject> spheres = HalfCircleFormation(numberOfPoints, radius);
        // Create a list of colors.
       

        // Find the container variable that is used to hold child objects in the inspector.
        GameObject sphereContainer = GameObject.Find("SphereContainer");

        // Loop through the numberOfMeridians.
        // Meridians are the amount of half circles you want to create.
        for(int i = 1; i < numberOfMeridians; i++)
        {// Get the angle of the current index being instantiated from the center.
            float phi = 2 * Mathf.PI * ((float)i / (float)numberOfMeridians);

            // Loop through the numberOfPoints you want to spawn in this meridian
            for(int j = 1; j < numberOfPoints; j++)
            {
                // Instantiate the prefab.
                GameObject instance = Instantiate(Sphere3);

                // Get the X position of the current sphere being viewed.
                float X = spheres[j].transform.position.x;
                // Get the Y position of the current sphere being viewed.
                float Y = spheres[j].transform.position.y * Mathf.Cos(phi) - spheres[j].transform.position.z * Mathf.Sin(phi);
                // Get the Z position of the current sphere being viewed.
                float Z = spheres[j].transform.position.z * Mathf.Cos(phi) + spheres[j].transform.position.y * Mathf.Sin(phi);

                // Set the instantiated gameObjects position to a new Vector3 with the new variables.
                instance.transform.position = new Vector3(X, Y, Z);
               
                // Set the instantiated object as a child of the container gameObject.
                instance.transform.SetParent(sphereContainer.transform);
            }
        }
    }    
}
    // Update is called once per frame
  
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
         myAudioSource.Stop();
       } */

    
