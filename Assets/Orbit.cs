using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    // Start is called before the first frame update
    public float a;
    public float e = 0;
    public float i = 0;
    public float RAAN = 0;
    public float omega = 0;
    public float nu = 0;

    public Rigidbody a_rb; // at periapsis
    public Rigidbody e_rb; // at focus 2
    public Rigidbody i_rb;
    public Rigidbody RAAN_rb;
    public Rigidbody omega_rb;
    public Rigidbody nu_rb;
    public Rigidbody focus;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        compute_a();
        compute_e();
        compute_RAAN();
        compute_omega();
        compute_nu();
        //place_a();
        //place_e();
        //place_i();
        //place_RAAN();
        //place_omega();
        //place_nu();
    }

    void compute_a()
    {
        Vector3 r_p = a_rb.position - focus.position;
        a = r_p.magnitude / (1 + e);
    }
    
    void compute_e()
    {
        Vector3 e2 = e_rb.position - focus.position;
        e = e2.magnitude / 2;
    }

    void compute_RAAN()
    {
        Vector3 RAAN_vec = RAAN_rb.position - focus.position;
        RAAN = Mathf.Atan2(RAAN_vec.z, RAAN_vec.x);
    }

    void compute_omega()
    {
//        Vector3 omega_vec = omega_rb.position - RAAN_rb.position;
        omega = Vector3.Angle(omega_rb.position, RAAN_rb.position);//.Atan2(RAAN_vec.z, RAAN_vec.x);
    }

    void compute_nu()
    {
        //        Vector3 omega_vec = omega_rb.position - RAAN_rb.position;
        nu = Vector3.Angle(nu_rb.position, omega_rb.position);//.Atan2(RAAN_vec.z, RAAN_vec.x);
    }
}
