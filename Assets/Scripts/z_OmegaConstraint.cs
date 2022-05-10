using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmegaConstraint : MonoBehaviour
{
    public Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 localPosition = transform.InverseTransformDirection(rigidbody.position);
        localPosition.x = 0;
        localPosition.z = 0;

        rigidbody.position = transform.TransformDirection(localPosition);
    }
}
