using UnityEngine;

public class Height : MonoBehaviour
{
    [SerializeField]
    private HandPrs Collider;
    [SerializeField]
    private float heightFt;
    [SerializeField]
    private float heightIn;
    private float heightPreM;
    void Start()
    {
        heightFt *=  12;
        heightPreM = heightFt += heightIn;
        Collider.bodyHeightMax = heightPreM *= 0.0254f;;
    }
}