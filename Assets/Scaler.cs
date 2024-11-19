using UnityEngine;

[ExecuteAlways]
class Scaler : MonoBehaviour
{
    [SerializeField] Vector3 localCenter;
    [SerializeField] float localSize; // Local Size 
     
    [SerializeField] float currentDistance;


    void Update()
    { 
        transform.localScale = Vector3.one * (GetRealSize() / localSize);

        Vector3 sphereCenterGlobal = Vector3.forward * currentDistance;
        Vector3 offsetVector = transform.TransformVector(localCenter);

        transform.position = sphereCenterGlobal - offsetVector;
    }

    float GetRealSize()
    {
        const float referenceDistance = 0.4f;        // 40 cm
        const float sizeInRefernceDistance = 0.01f;  // 1 cm

        float alphaRad = Mathf.Atan(sizeInRefernceDistance / (2 * referenceDistance)) * 2;
        // alphaDeg = alphaRad * Mathf.Rad2Deg;

        float realSize = 2 * currentDistance * Mathf.Tan(alphaRad / 2);
        return realSize;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        // Gizmos.matrix = transform.localToWorldMatrix;

        Vector3 global = transform.TransformPoint(localCenter);
        Gizmos.DrawWireSphere(global, GetRealSize() / 2);

        // Gizmos.matrix = Matrix4x4.identity;
    }
}