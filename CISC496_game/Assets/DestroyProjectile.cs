using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// -----------
/// CISC 496 - Group P1 - Project: Eye Say
/// Description: Code to destroy projectile and target once it has collided with and object, and then plays a particle effect
/// How to use: Script should be already be attached to the projectile prefab
///     If the other is tagged "destructible" they will be destroyed, otherwise only the projectile is destroyed
///     Tag killable enemies and destructible hazards with "destructible"
/// Written by: Sammy Chan
/// ---------- 

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
