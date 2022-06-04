using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Orbit2 : MonoBehaviour
{


    // Start is called before the first frame update
    public float a;
    public float e = 0;
    public float i = 0;
    public float RAAN = 0;
    public float omega = 0;
    public float nu = 0;

    void Start()
    {
        a = 1;
        e = 0.5f;
        i = Mathf.Deg2Rad * 45;
        RAAN = Mathf.Deg2Rad * 30;
        omega = Mathf.Deg2Rad * 90;
        nu = Mathf.Deg2Rad * 135;
    }


    // Update is called once per frame
    void Update()
    {
    }


}
