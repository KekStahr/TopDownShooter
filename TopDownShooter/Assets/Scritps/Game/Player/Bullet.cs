using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class Bullet : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.GetComponent<EnemyMovement>()) {
            HealthBar healthBar = collision.GetComponent<HealthBar>();
            healthBar.TakeDamage(5);
            Destroy(gameObject);
        }
    }
    
}
