using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFunction : MonoBehaviour
{
Collider2D[] inExplosionRadius = null;
[SerializeField] private float ExplosionForceMultiplier = 5;
[SerializeField] private float ExplosionRadius = 5;

public void Update()
{
    Explode();
}

void Explode ()
{
    inExplosionRadius = Physics2D.OverlapCircleAll(transform.position, ExplosionRadius);

    foreach (Collider2D o in inExplosionRadius)
    {
        Rigidbody2D o_rigidbody = o.GetComponent<Rigidbody2D>();
        Debug.Log(o_rigidbody + "has exploded.");
        if(o_rigidbody != null)
        {
            Vector2 distanceVector = o.transform.position - transform.position;
            if (distanceVector.magnitude > 0) //avoids NaN error)
            {
                float explosionForce = ExplosionForceMultiplier/distanceVector.magnitude;
                o_rigidbody.AddForce(distanceVector.normalized * explosionForce);
            }
        }
    }
}
}
