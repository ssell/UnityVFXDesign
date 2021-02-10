using System;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    private Vector3 StartPosition;
    public Transform MoveTowards;
    public float MoveSpeed;

    public GameObject Body;
    public GameObject Trails;
    public GameObject Impact;

    public bool Ready;
    private bool HasCollided;
    private bool DisabledTrails;

    public void Reset()
    {
        Ready = false;
        HasCollided = false;
        DisabledTrails = false;
        transform.position = StartPosition;

        Body.SetActive(true);
        Impact.SetActive(false);

        ToggleSystemsIn(Trails, true);
        ToggleSystemsIn(Impact, false);
    }

    private void Start()
    {
        StartPosition = transform.position;
    }

    private void Update()
    {
        if (!Ready)
        {
            return;
        }

        if (!HasCollided)
        {
            Vector3 target = MoveTowards.position;
            Vector3 toTarget = (target - transform.position).normalized;
            Vector3 velocity = toTarget * (MoveSpeed * Time.deltaTime);

            transform.position += velocity;
            Body.transform.LookAt(target, Vector3.up);
        }
        else
        {
            if (!DisabledTrails)
            {
                DisabledTrails = true;
                ToggleSystemsIn(Trails, false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        HasCollided = true;
        Body.SetActive(false);

        Impact.SetActive(true);
        ToggleSystemsIn(Impact, true);
    }

    private void ToggleSystemsIn(GameObject gameObject, bool active)
    {
        var systems = gameObject.GetComponentsInChildren<ParticleSystem>();

        foreach (var system in systems)
        {
            if (active)
            {
                system.Play();
            }
            else
            {
                system.Stop();
            }
        }
    }
}
