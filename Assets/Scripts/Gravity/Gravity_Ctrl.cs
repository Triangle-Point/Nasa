using UnityEngine;
public class Gravity_Ctrl : MonoBehaviour
{
    public Grabity_Orbit gravity;
    public Rigidbody rB;
    public float rotationSpeed = 20;
    private VRMovement move;

    void Update()
    {
        if(gravity)
        {
            Vector3 gravityUp = Vector3.zero;


            gravityUp = (transform.position - gravity.transform.position).normalized;

            Vector3 localUp = transform.up;

            Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * transform.rotation;
            rB.GetComponent<Rigidbody>().rotation = targetRotation;

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            rB.AddForce((-gravityUp * gravity.Gravity) * rB.mass);
        }
    }
}