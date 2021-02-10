using System;
using UnityEngine;

public sealed class MoveBackAndForth : MonoBehaviour
{
    public Transform PointA;
    public Transform PointB;
    public float Rate;
    public bool WrapAround;
    public bool Paused;

    private float Elapsed;

    void Update()
    {
        if (Paused)
        {
            return;
        }

        Elapsed += Time.deltaTime;

        if (WrapAround)
        {
            float t = Elapsed * Rate;
            float f = t - (float)Math.Truncate(t);
            Vector3 next = Vector3.Lerp(PointA.transform.position, PointB.transform.position, f);

            transform.LookAt(next, Vector3.up);
            transform.position = next;
        }
        else
        {
            float f = (Mathf.Cos(Elapsed * Rate) + 1.0f) * 0.5f;
            transform.position = Vector3.Lerp(PointA.transform.position, PointB.transform.position, f);
        }
    }
}