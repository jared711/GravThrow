using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.XR.Interaction.Toolkit
{
public class NodeGrabbable : XRGrabInteractable
    {
        public Transform node;
        //public Rigidbody node;
        //Rigidbody rb;
        //bool _isgrabbed;
        // Start is called before the first frame update
        void Start()
        {
            //_isgrabbed = false;
            //rb = GetComponent<Rigidbody>();
//            Vector3 relvec = target.position - rb.position;
  //          if (relvec.magnitude > 0.01)
    //            rb.MovePosition(target.position);
        }

        // Update is called once per frame
/*        void FixedUpdate()
        {
            if (_isgrabbed)
            {
                rb.MovePosition(node.position);
            }
        }*/

/*        protected override void OnSelectEntering(SelectEnterEventArgs args)
        {
            base.OnSelectEntering(args);
            Grab();
            _isgrabbed = true;
            Debug.Log("I grabbed it");
            Debug.Log(_isgrabbed);

        }*/

        protected override void OnSelectExiting(SelectExitEventArgs args)
        {
            base.OnSelectExiting(args);
            Drop();
            //_isgrabbed = false;
            //Debug.Log("I dropped it");

            transform.position = node.transform.position;
            //transform.rotation = node.transform.rotation;
            //Debug.Log(_isgrabbed);
            //Debug.Log("Exiting Grab");
            /*Vector3 relvec = node.position - rb.position;
            if (relvec.magnitude > 0.01)
            {
                Debug.Log(rb.position);
                Debug.Log(node.position);
                Debug.Log("Moving grabbable node back to node position");
                
                //rb.position = node.position;//rb.MovePosition(node.position);
                Debug.Log(rb.position);
                Debug.Log(node.position);
            }*/

        }
    }
}