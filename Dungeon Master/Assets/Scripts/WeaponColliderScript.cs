using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponColliderScript : MonoBehaviour
{
    public GameObject player;
    private float weaponDamage;

    private void Start()
    {
        Debug.Log("WeaponColliderScript is running");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D called with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit detected");
            var enemyScript = collision.gameObject.GetComponent<EnemyScript>();
            if (enemyScript != null)
            {
                Debug.Log("Applying damage to enemy");
                enemyScript.TakeDamage(1);
            }
            else
            {
                Debug.LogError("EnemyScript component not found on the enemy");
            }
        }
    }
}
