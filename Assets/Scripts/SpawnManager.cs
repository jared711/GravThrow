using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpawnManager : MonoBehaviour
{
    public GameObject particle;

    public Slider sliderUI;


    //public GameObject appear;

    //bool hasExploded = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Replace()
    {
        //GameObject new_particle;
        //Instantiate(appear, new Vector3(-1.868f, 1.041f, 1.301f), Quaternion.identity);
        float prevMass = particle.GetComponent<Rigidbody>().mass;
        Vector3 prevLocalScale = particle.transform.localScale;

        particle.GetComponent<Rigidbody>().mass = sliderUI.value;
        float scale = 0.15f + (float)(sliderUI.value - 1f) / 50f;
        particle.transform.localScale = new Vector3(scale, scale, scale);
        Instantiate(particle, new Vector3(-1.868f, 1.041f, 1.301f), Quaternion.identity);
        particle.GetComponent<Rigidbody>().mass = prevMass;
        particle.transform.localScale = prevLocalScale;

        //new_particle.Particle.Activate(); 
    }

}
