using UnityEngine;

public class PlayerDamagedIn : MonoBehaviour
{

    [SerializeField] private float invincibilityDuration;
    private Invincibility invincibility;

    private void Awake(){
        invincibility = GetComponent<Invincibility>();
    }
    
    public void StartInvincibility(){
        invincibility.StartInvincibility(invincibilityDuration); 
    }
}
