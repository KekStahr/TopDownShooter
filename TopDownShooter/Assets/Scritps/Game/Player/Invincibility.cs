using UnityEngine;
using System.Collections;

public class Invincibility : MonoBehaviour
{
    private HealthBar healthBar;

    private void Awake(){
        healthBar = GetComponent<HealthBar>();
    }

   public void StartInvincibility(float invincibilityDuration){
        StartCoroutine(InvincibilityCoroutine(invincibilityDuration));
    }

    private IEnumerator InvincibilityCoroutine(float invincibilityDuration){
        healthBar.IsInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        healthBar.IsInvincible = false;
    }
}
