using UnityEngine;

class Trigoinometry : MonoBehaviour
{
    [SerializeField] float d = 0.4f;
    [SerializeField] float s = 0.01f;
    [SerializeField] float d2 = 5;

    [SerializeField] float alphaDeg;
    [SerializeField] float s2;

    void OnValidate()
    {
        float alphaRad = Mathf.Atan(s / (2 * d)) * 2;
        alphaDeg = alphaRad * Mathf.Rad2Deg;

        s2 = 2 * d2 * Mathf.Tan(alphaRad / 2);
    }
}
