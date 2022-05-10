using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.XR.Interaction.Toolkit
{
public class NodeGrabbable : XRGrabInteractable
    {
        public Rigidbody node;
        Rigidbody rb;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
//            Vector3 relvec = target.position - rb.position;
  //          if (relvec.magnitude > 0.01)
    //            rb.MovePosition(target.position);
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        protected override void OnSelectExiting(SelectExitEventArgs args)
        {
            base.OnSelectExiting(args);
            Drop();
            //Debug.Log("Exiting Grab");
            Vector3 relvec = node.position - rb.position;
            if (relvec.magnitude > 0.01)
                rb.MovePosition(node.position);
        }
    }
}