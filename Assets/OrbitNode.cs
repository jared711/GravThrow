using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitNode : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.position = new Vector3(1,1,1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
