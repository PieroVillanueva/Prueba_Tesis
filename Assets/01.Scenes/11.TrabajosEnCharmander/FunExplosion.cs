using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunExplosion : MonoBehaviour
{
    public float radius = 5.0F;
    public float power = 10.0F;
    public Collider[] colliders;

    public ForceMode modo;
    void OnEnable()
    {
        Vector3 explosionPos = transform.position;
        colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F,modo);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.2f);
        Gizmos.DrawSphere(transform.position, radius);
    }
    IEnumerator aplicarExplosion()
    {
        yield return new WaitForSeconds(2.0f);
    }
}
