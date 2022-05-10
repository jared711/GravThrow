using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {

    }
    
    public void Replace()
    {
        //GameObject new_particle;
        Instantiate(particle, new Vector3(-1.868f, 1.041f, 1.301f), Quaternion.identity);
        //new_particle.Particle.Activate(); 
    }
}
