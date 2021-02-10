using System;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    public Transform MoveTowards;
    public float MoveSpeed;

    public GameObject Body;
    public GameObject Trails;
    public GameObject Impact;

    public bool Ready;
    private bool HasCollided;
    private bool DisabledTrails;

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
        Body.gameObject.SetActive(false);

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
