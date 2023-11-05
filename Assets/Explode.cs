using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public float explosionForce = 10f;
    public float explosionRadius = 5f;

    private void Start()
    {
        // Применяем взрывную силу к объектам внутри радиуса взрыва
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Применяем силу к объекту, чтобы он отскочил от взрыва
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Отрисовка радиуса взрыва в редакторе Unity
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
