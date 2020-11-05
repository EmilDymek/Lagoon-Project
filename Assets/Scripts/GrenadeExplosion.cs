using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour
{
    public int grenadeDamage;

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag != "Player" && hitInfo.tag != "Grenade")
        {
            if (hitInfo.tag == "Enemy")
            {
                EnemyBehaviour enemy = hitInfo.GetComponent<EnemyBehaviour>();
                enemy.TakeDamage(grenadeDamage);
                Debug.Log("Damage!!");
            }
            Debug.Log("BLEB!");
        }
    }
}
