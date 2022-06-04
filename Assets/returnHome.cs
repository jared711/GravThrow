using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.XR.Interaction.Toolkit
{
    public class returnHome : MonoBehaviour
    {
        public Rigidbody node;
        Rigidbody rb;
        XRGrabInteractable xrg;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            xrg = GetComponent<XRGrabInteractable>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            //Debug.Log(rb);
            //Debug.Log(node);
            if (xrg.isSelected)
            {
                node.MovePosition(rb.position);
            }
            else
            {
                rb.MovePosition(node.position);
            }


        } 
    }

}