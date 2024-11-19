using UnityEngine;
public class PathPoint : MonoBehaviour
{
    [SerializeField] float time= 1;
    [SerializeField] float range= 0.1f;

    void OnDrawGizmos()
    {

        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireSphere(Vector3.zero, range);
        Gizmos.DrawLine(Vector3.zero, Vector3.forward * range * 2);
        Gizmos.matrix = Matrix4x4.identity;
    }
}
