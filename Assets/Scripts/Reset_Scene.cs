using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Reset_Scene : MonoBehaviour
{
    [SerializeField] private InputActionReference Reset;

    void OnEnable()
    {
        Reset.action.performed += Reseting;
    }

    void OnDisable()
    {
        Reset.action.performed -= Reseting;
    }

    void Reseting(InputAction.CallbackContext obj)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
