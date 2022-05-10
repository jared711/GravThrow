using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iConstraint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 localPosition = transform.InverseTransformDirection(GetComponent<Rigidbody>().position);
        localPosition.y = 0;
        float x_prev = localPosition.x;
        float z_prev = localPosition.z;
        localPosition.x = x_prev / Mathf.Sqrt(x_prev * x_prev + z_prev * z_prev);
        localPosition.z = z_prev / Mathf.Sqrt(x_prev * x_prev + z_prev * z_prev);

        GetComponent<Rigidbody>().position = transform.TransformDirection(localPosition);
    }
}
