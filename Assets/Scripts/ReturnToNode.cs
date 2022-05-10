using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToNode : MonoBehaviour
{
    //public XRGrabInteractable xrgrab;
    public Rigidbody parent;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relvec = rb.position - parent.position;
        if (relvec.magnitude > 0.1)
        {
            rb.position = parent.position;
        }

    }

    public void Return()
    {
        rb.MovePosition(parent.transform.position);
    }
}
