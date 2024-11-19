using UnityEngine;

[ExecuteAlways]
public class LookAt : MonoBehaviour
{
    [SerializeField] Transform target;
    void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;   // Irány kiszámol
            direction.y = 0;                                            // Függõleges komponnes kiüt
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
