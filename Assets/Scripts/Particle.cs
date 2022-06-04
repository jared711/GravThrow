using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    const float G = 1.0f;

    public static List<Particle> Particles;
    public Rigidbody rb;
    private bool _activated;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Starting");
        rb = GetComponent<Rigidbody>();
        _activated = true;
        rb.useGravity = false;
        rb.drag = 0;
    }

    public void Activate()
    {
        _activated = true;
        rb.useGravity = false;
        rb.drag = 0;
    }

    public void Deactivate()
    {
        _activated = false;
        rb.useGravity = true;
        rb.drag = 2;

    }
    void FixedUpdate()
    {
        if (_activated)
        {
            foreach (Particle particle in Particles)
            {
                if (particle != this && particle.IsActive())
                {
                    Attract(particle);
                }

            }
        }

    }
    public bool IsActive()
    {
        return _activated;
    }
    void OnEnable()
    {
        if (Particles == null)
            Particles = new List<Particle>();
        //Debug.Log("Adding to Particles List");
        Particles.Add(this);
        //Debug.Log(Particles.Count);
    }

    void OnDisable()
    {
        //Debug.Log("Removing from Particles List");
        Particles.Remove(this);
    }
    void Attract(Particle particle)
    {
        Rigidbody rbToAttract = particle.rb;
        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        if (distance == 0)
            return;

        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }
}