using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{

    public GameObject particle;
    private float elapsedTime;

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
        if (other.gameObject.tag == "destructible")
        {
            Destroy(other.gameObject);
        }
        GameObject explodeFX = Instantiate(particle, transform.position, Quaternion.identity);
        if (!(explodeFX == null))
        {
            Destroy(explodeFX, 0.5f);
        }

    }
}
