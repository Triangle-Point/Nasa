using UnityEngine;
using UnityEngine.InputSystem;
public class PhysicsGrab : MonoBehaviour
{
    public InputActionProperty grabInputSource;
    public float radius = 0.1f;
    public LayerMask garbLayer;
    private FixedJoint fixedJoint;
    private bool isGrabbing = false;
    public Transform Parent;
    public Transform TREParent;
    public Transform test;
    void FixedUpdate()
    {
        bool isGrabButtonPressed = grabInputSource.action.ReadValue<float>() > 0.1f;

        if(isGrabButtonPressed && !isGrabbing)
        {
            Collider[] nearbyColliders = Physics.OverlapSphere(transform.position, radius, garbLayer, QueryTriggerInteraction.Ignore);

            if(nearbyColliders.Length > 0)
            {
                Rigidbody nearbyRigidbody = nearbyColliders[0].attachedRigidbody;

                fixedJoint = gameObject.AddComponent<FixedJoint>();
                fixedJoint.autoConfigureConnectedAnchor = false;


                if(nearbyRigidbody)
                {
                    fixedJoint.connectedBody = nearbyRigidbody;
                    fixedJoint.connectedAnchor = nearbyRigidbody.transform.InverseTransformPoint(transform.position);
                }
                else
                {
                    fixedJoint.connectedAnchor = transform.position;
                }

                isGrabbing = true;
            }
        }
        else if (!isGrabButtonPressed && isGrabbing)
        {
            isGrabbing = false;

            if(fixedJoint)
            {
                Destroy(fixedJoint);
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if(isGrabbing)
        {
            if(other.CompareTag("Grabable"))
            {
                other.transform.parent = Parent.transform;
            }
        }
    }   
    void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}