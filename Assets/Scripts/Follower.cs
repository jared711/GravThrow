using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform target;
    public GameObject orbit;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //Vector3 relvec = target.position - rb.position;
        //if (relvec.magnitude > 0.01)
        //Debug.Log("I should be following");
        Physics.SyncTransforms();

        rb.MovePosition(target.transform.position);
    }

}
