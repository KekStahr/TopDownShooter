using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;

    private Rigidbody2D _rigidbody;
    private PlayerAwareness playerAwareness;
    
    private Vector2 targetDirection;
    private bool facingRight = true;

    private float fixedZRotation = 0f;

    private void Awake(){
        _rigidbody = GetComponent<Rigidbody2D>();
        playerAwareness = GetComponent<PlayerAwareness>();

        if (_rigidbody == null)
        {
            Debug.LogWarning("Rigidbody2D-Komponente fehlt am Enemy-Objekt!");
        }
    }

    private void UpdateTargetDirection(){
        if (playerAwareness != null && playerAwareness.AwareOfPlayer){
            targetDirection = playerAwareness.DirectionToPlayer;
        }
        else{
            targetDirection = Vector2.zero; 
        }
    }

    private void RotateTowardsTarget(){
        if(targetDirection == Vector2.zero || _rigidbody == null){
            return;
        }
        
        FlipSprite();
    }

    private void SetVelocity(){
        if (_rigidbody == null) return;

        if (targetDirection == Vector2.zero) {
            _rigidbody.linearVelocity = Vector2.zero;
        }
        else {
            _rigidbody.linearVelocity = targetDirection.normalized * speed;
        }
    }

    private void FlipSprite()
    {
        if (targetDirection.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (targetDirection.x < 0 && facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void FixedUpdate()
    {
        UpdateTargetDirection(); 
        RotateTowardsTarget();
        SetVelocity();
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, fixedZRotation);
    }
}
