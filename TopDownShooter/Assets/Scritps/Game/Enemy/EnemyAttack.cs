using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    
    [SerializeField] private float attackDamage;

    private void OnCollisionStay2D(Collision2D collision){
        if(collision.gameObject.GetComponent<PlayerMovement>()){
            var healthController = collision.gameObject.GetComponent<HealthBar>();
            healthController.TakeDamage(attackDamage);
        }
    }
}
