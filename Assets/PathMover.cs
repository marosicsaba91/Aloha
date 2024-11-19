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
            float t = Mathf.Clamp01(time / durationIn);   // Beszor�t egy �rt�ket 0 �s 1 k�z�
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
        t = curve.Evaluate(t);   // �rt�k kiolvas�sa egy f�ggv�nyb�l:    Mi az y egy adott x-re?
        spline.Evaluate(t, out float3 p, out float3 f, out float3 u);    // �rt�k kiolvas�sa spline-b�l  (0-1)

        transform.SetPositionAndRotation(p, Quaternion.LookRotation(f, u));
    }
}
