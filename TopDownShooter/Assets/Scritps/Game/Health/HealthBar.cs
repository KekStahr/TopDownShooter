using UnityEngine;
using UnityEngine.Events;
public class HealthBar : MonoBehaviour
{
    [SerializeField] private float currentHealth;

    [SerializeField] private float maxHealth;

    public bool IsInvincible{get; set;}

    public UnityEvent OnDied;

    public UnityEvent OnDamaged;

    public UnityEvent OnHealthChanged;

    public float RemainingHealthPercentage{
        get{
            return currentHealth / maxHealth;
        }
    }

    public void TakeDamage(float damageAmount){

        if(currentHealth == 0 ){
            // If character is dead, destroy it.
            // TODO: CHANGE THIS ONE !! 
            Destroy(gameObject);
        }

        if(IsInvincible){
            return;
        }

        currentHealth -= damageAmount;

        OnHealthChanged.Invoke();

        if(currentHealth < 0){
            currentHealth = 0;
        }

        if(currentHealth == 0){
            OnDied.Invoke();
        }
        else{
            OnDamaged.Invoke();
        }
    }

    public void AddHealth(float amountToAdd){
        if(currentHealth == maxHealth){
            return;
        }

        currentHealth += amountToAdd;

        OnHealthChanged.Invoke();

        if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }
    }

    
}
