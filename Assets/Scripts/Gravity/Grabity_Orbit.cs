using UnityEngine;

public class Grabity_Orbit : MonoBehaviour
{
    public float Gravity;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Gravity_Ctrl>())
        {
            other.GetComponent<Gravity_Ctrl>().gravity = this.GetComponent<Grabity_Orbit>();
        }
    }
}
