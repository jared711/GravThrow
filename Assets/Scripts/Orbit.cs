using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Orbit : MonoBehaviour
{

    private XRGrabInteractable interactor = null;

    private void Awake()
    {
        interactor = GetComponent<XRGrabInteractable>();
    }

    // Start is called before the first frame update
    public float a;
    public float e = 0;
    public float i = 0;
    public float RAAN = 0;
    public float omega = 0;
    public float nu = 0;

    public Transform a_node; // at periapsis
    public Transform e_node; // at focus 2
    public Transform i_node;
    public Transform RAAN_node;
    public Transform omega_node;
    public Transform nu_node;
    public Transform focus;

    public Transform RAAN_plane;
    public Transform i_plane;
    public Transform omega_plane;


    void Start()
    {
        transform.position = focus.position;
        a = 1;
        e = 0.5f;
        i = Mathf.Deg2Rad * 0;
        RAAN = Mathf.Deg2Rad * 0;
        omega = Mathf.Deg2Rad * 0;
        nu = Mathf.Deg2Rad * 0;
        set_up_initial_positions();
    }

    void set_up_initial_positions()
    {
        a_node.localPosition = new Vector3(-a * (1 + e), 0, 0);
        e_node.localPosition = new Vector3(-2*a*e, 0, 0);
        omega_node.localPosition = new Vector3(a * (1 - e) * Mathf.Cos(omega), 0, a * (1 - e) * Mathf.Sin(omega));
        i_node.localPosition = new Vector3(0, Mathf.Sin(i), Mathf.Cos(i));
        RAAN_node.localPosition = new Vector3(a * (1 - e * e) * Mathf.Cos(RAAN), 0, a * (1 - e * e) * Mathf.Sin(RAAN));
        
        float u = omega + nu;
        float r = a * (1 - e * e) / (1 + e * Mathf.Cos(nu));
        //float x = r * (Mathf.Cos(u) * Mathf.Cos(RAAN) - Mathf.Sin(u) * Mathf.Cos(i) * Mathf.Sin(RAAN));
        //float y = r * (Mathf.Cos(u) * Mathf.Sin(RAAN) + Mathf.Sin(u) * Mathf.Cos(i) * Mathf.Cos(RAAN));
        //float z = r * (Mathf.Sin(u) * Mathf.Sin(i));
        nu_node.localPosition = new Vector3(r*Mathf.Cos(nu), 0, r*Mathf.Sin(nu));
    }


    // Update is called once per frame
    void Update()
    {
        //if (interactor != null) Debug.Log("Interacting");
        //else Debug.Log("Interacting");

        compute_RAAN();
        compute_i();
        compute_omega();
        compute_a();
        compute_e();
        compute_nu();

        
        //place_a();
        //place_e();
        //place_i();
        //place_RAAN();
        //place_omega();
        //place_nu();

        //Quaternion target = Quaternion.Euler(0, Mathf.Rad2Deg*omega, 0);
        //transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime*5.0f);
        RAAN_plane.localRotation = Quaternion.Euler(0, -Mathf.Rad2Deg * RAAN, 0);
        i_plane.localRotation = Quaternion.Euler(-Mathf.Rad2Deg * i, 0, 0);
        omega_plane.localRotation = Quaternion.Euler(0, -Mathf.Rad2Deg * omega, 0);
    }

    void compute_a()
    {
        Vector3 localPosition = a_node.localPosition;
        if (localPosition.x >= 0)
        {
            localPosition.x = -0.01f;
        }
        if (localPosition.x >= e_node.localPosition.x)
        {
            localPosition.x = 1.01f * e_node.localPosition.x;
        }
        localPosition.y = 0;
        localPosition.z = 0;

        a = Mathf.Abs(a_node.localPosition.x) / (1 + e); //Mathf.Abs(a_node.localPosition.x) is the distance to apoapsis r_a

        a_node.localPosition = localPosition;

        //Vector3 r_p = a_node.position - transform.position;
        //a = r_p.magnitude / (1 + e);
    }
    
    void compute_e()
    {
        Vector3 localPosition = e_node.localPosition;
        if (localPosition.x > 0)
        {
            localPosition.x = 0;
        }
        localPosition.y = 0;
        localPosition.z = 0;
        //localPosition.x = a_node.localPosition.x * e;
        e = e_node.localPosition.x / a_node.localPosition.x;

        e_node.localPosition = localPosition;


        //Vector3 e2 = e_node.position - transform.position;
        //e = e2.magnitude / 2;
    }
  
    void compute_RAAN()
    {
        Vector3 localPosition = RAAN_node.localPosition;
        float x_prev = localPosition.x;
        float z_prev = localPosition.z;
        float r = a * (1 - e * e) / (1 + e * Mathf.Cos(-omega));
        localPosition.x = r * x_prev / Mathf.Sqrt(x_prev * x_prev + z_prev * z_prev);
        localPosition.z = r * z_prev / Mathf.Sqrt(x_prev * x_prev + z_prev * z_prev);
        localPosition.y = 0;
        RAAN = Mathf.Atan2(localPosition.z, localPosition.x); 

        RAAN_node.localPosition = localPosition; 


        //omega = Vector3.Angle(omega_node.position, RAAN_node.position);//.Atan2(RAAN_vec.z, RAAN_vec.x);
        //Vector3 RAAN_vec = RAAN_node.position - transform.position;
        //RAAN = Mathf.Atan2(RAAN_vec.z, RAAN_vec.x);
    }

    void compute_i()
    {
        Vector3 localPosition = i_node.localPosition;
        float z_prev = localPosition.z;
        float y_prev = localPosition.y;
        float r = a * (1 - e * e) / (1 + e * Mathf.Cos(-omega + Mathf.Deg2Rad*90));
        localPosition.z = r * z_prev / Mathf.Sqrt(z_prev * z_prev + y_prev * y_prev);  
        localPosition.y = r * y_prev / Mathf.Sqrt(z_prev * z_prev + y_prev * y_prev); 
        localPosition.x = 0;
        i = Mathf.Atan2(localPosition.y, localPosition.z);

        i_node.localPosition = localPosition;

        //omega = Vector3.Angle(omega_node.position, RAAN_node.position);//.Atan2(RAAN_vec.z, RAAN_vec.x);
        
        //Vector3 RAAN_vec = RAAN_node.position - transform.position;
        //RAAN = Mathf.Atan2(RAAN_vec.z, RAAN_vec.x);
    }
    void compute_omega()
    {
        //        Vector3 omega_vec = omega_node.position - RAAN_node.position;
        Vector3 localPosition = omega_node.localPosition;
        float x_prev = localPosition.x;
        float z_prev = localPosition.z;
        localPosition.x = a * (1 - e) * x_prev / Mathf.Sqrt(x_prev * x_prev + z_prev * z_prev);
        localPosition.z = a * (1 - e) * z_prev / Mathf.Sqrt(x_prev * x_prev + z_prev * z_prev);
        localPosition.y = 0;
        
        omega = Mathf.Atan2(localPosition.z, localPosition.x);

        omega_node.localPosition = localPosition;


        //omega = Vector3.Angle(omega_node.position, RAAN_node.position);//.Atan2(RAAN_vec.z, RAAN_vec.x);
    }
    
    void compute_nu()
    {
        //        Vector3 omega_vec = omega_node.position - RAAN_node.position;
        Vector3 localPosition = nu_node.localPosition;
        float r = a * (1 - e * e) / (1 + e * Mathf.Cos(nu));
        float x_prev = localPosition.x;
        float z_prev = localPosition.z;

        localPosition.x = r * x_prev / Mathf.Sqrt(x_prev * x_prev + z_prev * z_prev);
        localPosition.z = r * z_prev / Mathf.Sqrt(x_prev * x_prev + z_prev * z_prev);
        localPosition.y = 0;
        nu = Mathf.Atan2(localPosition.z, localPosition.x);

        nu_node.localPosition = localPosition;


        //omega = Vector3.Angle(omega_node.position, RAAN_node.position);//.Atan2(RAAN_vec.z, RAAN_vec.x);

        //        Vector3 omega_vec = omega_node.position - RAAN_node.position;
        //nu = Vector3.Angle(nu_node.position, omega_node.position);//.Atan2(RAAN_vec.z, RAAN_vec.x);
    }

    void auto_nu()
    {
        //        Vector3 omega_vec = omega_node.position - RAAN_node.position;
        float n = Mathf.Sqrt(1f / (a * a * a));
        float M = n * (float)Time.fixedUnscaledTimeAsDouble;
        nu += Mathf.Deg2Rad * 1f;

        Vector3 localPosition = nu_node.localPosition;
        float r = a * (1 - e * e) / (1 + e * Mathf.Cos(nu));
        
        localPosition.x = r * Mathf.Cos(nu);
        localPosition.z = r * Mathf.Sin(nu);
        localPosition.y = 0;
        
        nu = Mathf.Atan2(localPosition.z, localPosition.x);

        nu_node.localPosition = localPosition;


        //omega = Vector3.Angle(omega_node.position, RAAN_node.position);//.Atan2(RAAN_vec.z, RAAN_vec.x);

        //        Vector3 omega_vec = omega_node.position - RAAN_node.position;
        //nu = Vector3.Angle(nu_node.position, omega_node.position);//.Atan2(RAAN_vec.z, RAAN_vec.x);
    }

}
