using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] Transform start;
    [SerializeField] Transform end;
    [SerializeField] float duration;

    float startTime;

    void Start()
    {
        transform.position = start.position;
        transform.rotation = start.rotation;
        startTime = Time.time;
    }

    void Update()
    {
        float distance = Vector3.Distance(start.position, end.position); 
        float speed = distance / duration;

        //Vector3 direction = (end.position - transform.position).normalized;
        //transform.position += direction * (speed * Time.deltaTime);

        float age = Time.time - startTime;
        float t = Mathf.Clamp01(age / duration);

        transform.position = Vector3.MoveTowards(transform.position, end.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(start.rotation, end.rotation, t);
    }
}
