using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeOrbitalElements : MonoBehaviour
{
    public Orbit2 orbit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void update_a(float a)
    {
        orbit.a = a;
    }

    public void update_e(float e)
    {
        orbit.e = e;
    }

    public void update_i(float i)
    {
        orbit.i = i;
    }

    public void update_Omega(float Omega)
    {
        orbit.RAAN = Omega;
    }

    public void update_omega(float omega)
    {
        orbit.omega = omega;
    }

    public void update_nu(float nu)
    {
        orbit.nu = nu;
    }
}
