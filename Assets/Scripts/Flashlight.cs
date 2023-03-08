using UnityEngine;
using UnityEngine.InputSystem;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private InputActionReference rightLight;
    [SerializeField] private InputActionReference leftLight;

    public GameObject lightObject;
    public Transform lightCheck;

    public bool holdingLight = false;
    public float lightDistance = 0.4f;
    public LayerMask Light;

    private bool lightOn = true;

    void OnEnable()
    {
        rightLight.action.performed += OnClick;
        leftLight.action.performed += OnClick;
    }

    void OnDisable()
    {
        rightLight.action.performed -= OnClick;
        leftLight.action.performed -= OnClick;
    }

    void Update()
    {
        holdingLight = Physics.CheckSphere(lightCheck.position, lightDistance, Light);

        if(lightOn == true)
        {
            lightObject.SetActive(true);
        }
        if(lightOn == false)
        {
            lightObject.SetActive(false);
        }
    }
    void OnClick(InputAction.CallbackContext obj)
    {
        if(holdingLight)
        {
            if(lightOn == false)
            {
                lightOn = true;
                return;
            }

            if(lightOn == true)
            {
                lightOn = false;
            }
        }
    }
}