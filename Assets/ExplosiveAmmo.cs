using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveAmmo : MonoBehaviour
{

    [SerializeField]
    private float explosionRadius = 5.0f;
    [SerializeField]
    private float power = 5.0f;

    private new Rigidbody rigidbody;
    private int destructibleLayer;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        destructibleLayer = LayerMask.NameToLayer("Destructible");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == destructibleLayer)
        {
            Debug.Log("BOOM!!!");
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
            //Add explosive force to all nearby rigidbodies
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null && hit.gameObject.layer == destructibleLayer)
                {
                    rb.AddExplosionForce(power, explosionPos, explosionRadius, 1.0F, ForceMode.Impulse);
                }
            }
        }

        //Destroy itself
        Destroy(gameObject);
    }

}