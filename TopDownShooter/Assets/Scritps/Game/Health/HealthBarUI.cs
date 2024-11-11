using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    
    [SerializeField] private UnityEngine.UI.Image healthBarImage;

    public void UpdateHealthBar(HealthBar healthBar){
        healthBarImage.fillAmount = healthBar.RemainingHealthPercentage;
    }
}
