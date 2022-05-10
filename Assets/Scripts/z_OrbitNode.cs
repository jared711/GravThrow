using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitNode : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void a_law()
    {
        //rb.position.x = 1;
        Debug.Log("Fixing y and z");
    }
 /*   public void a_law_exit()
    {
        //rb.position.x = 1;
        rb.constraints = null;
        Debug.Log("UNFixing y and z");
    }*/
}
