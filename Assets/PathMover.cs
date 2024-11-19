using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class PathMover : MonoBehaviour
{
    [SerializeField] SplineContainer pathIn;      // Unity Spline Package
    [SerializeField] SplineContainer pathOut;
    [SerializeField] float durationIn = 1;
    [SerializeField] float waitTime = 5;
    [SerializeField] float durationOut = 1;
    [SerializeField] AnimationCurve movementIn;   // float -> float function 
    [SerializeField] AnimationCurve movementOut;

    Coroutine coroutine;  // Running Coroutine

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))   // Key pressed
        {
            if (coroutine != null)
                StopCoroutine(coroutine);
            coroutine = StartCoroutine(MovementCoroutine());
        }
    }

    IEnumerator MovementCoroutine()
    {
        float time = 0;
        while (time <= durationIn)    // Moving In
        {
            time += Time.deltaTime;
            float t = Mathf.Clamp01(time / durationIn);   // Beszorít egy értéket 0 és 1 közé
            SetPose(t, pathIn.Spline, movementIn);
            yield return null;        // Wait until next frame 
        }
        SetPose(1, pathIn.Spline, movementIn);

        yield return new WaitForSeconds(waitTime);

        time = 0;
        while (time <= durationOut)
        {
            time += Time.deltaTime;
            float t = Mathf.Clamp01(time / durationOut);
            SetPose(t, pathOut.Spline, movementOut);
            yield return null;
        }

    }

    void SetPose(float t, Spline spline, AnimationCurve curve)  // Set the objects position & rotation based on spline
    {
        t = curve.Evaluate(t);   // Érték kiolvasása egy függvénybõl:    Mi az y egy adott x-re?
        spline.Evaluate(t, out float3 p, out float3 f, out float3 u);    // Érték kiolvasása spline-ból  (0-1)

        transform.SetPositionAndRotation(p, Quaternion.LookRotation(f, u));
    }
}
