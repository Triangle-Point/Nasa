using UnityEngine;
using UnityEngine.InputSystem;
using Unity.XR.CoreUtils;


public class VRMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference Jumpbutton;
    [SerializeField] private float jumpHeight;
    public XROrigin _xrOrigin;
    public Rigidbody rb;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    void OnEnable()
    {
        Jumpbutton.action.performed += OnJump;
    }

    void OnDisable()
    {
        Jumpbutton.action.performed -= OnJump;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    void OnJump(InputAction.CallbackContext obj)
    {
        if(!isGrounded)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            return;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
            rb.AddForce(transform.up * jumpHeight);
        }
    }
}