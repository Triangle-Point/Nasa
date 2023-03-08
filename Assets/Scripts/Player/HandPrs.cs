using UnityEngine;
public class HandPrs : MonoBehaviour
{
    public Transform playerHead;
    public CapsuleCollider bodyCollider;
    public float bodyHeightMin = 0.5f;
    public float bodyHeightMax = 2;
    public Transform LeftCon;
    public Transform RightCon;
    public ConfigurableJoint LeftJoint;
    public ConfigurableJoint RightJoint;
    public ConfigurableJoint HeadJoint;
    void FixedUpdate()
    {
        bodyCollider.height = Mathf.Clamp(playerHead.localPosition.y, bodyHeightMin, bodyHeightMax);
        bodyCollider.center = new Vector3(playerHead.localPosition.x,bodyCollider.height/2,
        playerHead.localPosition.z);


       LeftJoint.targetPosition = LeftCon.localPosition;
       LeftJoint.targetRotation = LeftCon.localRotation;

       RightJoint.targetPosition = RightCon.localPosition;
       RightJoint.targetRotation = RightCon.localRotation;

       HeadJoint.targetPosition = playerHead.localPosition;
    }
}
