using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerAwareness : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }
    public Vector2 DirectionToPlayer { get; private set; }
    [SerializeField] private float playerAwarenessDistance;
    private Transform player;

    private void Awake()
    {
        player = Object.FindFirstObjectByType<PlayerMovement>()?.transform;

        if(player == null){
            Debug.LogError("No PlayerMovement script found on the scene.");
        }
    }

    private void Update()
    {
        Vector2 enemyToPlayerVector = player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;
        
        if(enemyToPlayerVector.magnitude <= playerAwarenessDistance){
            AwareOfPlayer = true;
        }
        else{
            AwareOfPlayer = false;
        }
    }
}