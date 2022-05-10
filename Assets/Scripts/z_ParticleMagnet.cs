using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMagnet : MonoBehaviour
{
    public Transform transform;
    public Particle particle;
    // Start is called before the first frame update
    void Start()
    {
        particle.Deactivate();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = Vector3.Distance(particle.rb.position, transform.position);
        if (dist > 1)
        {
            particle.Activate();
        }
        if(dist < 1)
        {
            particle.Deactivate();
        }
    }
}
