using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleParticle : MonoBehaviour
{
    public GameObject particle;
    public GameObject explosion;
    public GameObject spawnpoint;

    const float G = 1.0f;
    public Rigidbody center;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Starting");
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.drag = 0;
    }


    void Update()
    {
        Attract(center);
    }

    void Attract(Rigidbody center)
    {
        Vector3 direction = center.position - rb.position;
        float distance = direction.magnitude;

        if (distance < 0.5)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Instantiate(particle, spawnpoint.transform.position, spawnpoint.transform.rotation);
            Destroy(particle);
            return; 
        }

        float forceMagnitude = G * (rb.mass * center.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        rb.AddForce(force);
    }
}