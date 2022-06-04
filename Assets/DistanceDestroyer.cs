using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDestroyer : MonoBehaviour
{
    public GameObject particle;
    public GameObject explosion;
    public float explodeDistance = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = particle.transform.position;
        //Debug.Log(pos);
        if (pos.magnitude > explodeDistance)
        {
            //Debug.Log(pos.magnitude); 
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(particle);
        }

    }
}
