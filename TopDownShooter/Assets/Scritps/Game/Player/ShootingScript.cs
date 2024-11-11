using UnityEngine;
using EZCameraShake;

public class ShootingScript : MonoBehaviour
{

    [SerializeField] public Transform Gun;

    Vector2 direction;

    public GameObject Bullet;

    [SerializeField] public float bulletSpeed;

    [SerializeField] public float fireRate;

     float ReadyForNextShot;

    public Transform ShootPoint;

    public Animator GunAnimator;

    private bool facingRight = true;

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - (Vector2)Gun.position).normalized;        

        FaceMouse();

        if(Input.GetMouseButton(0)){
            if(Time.time > ReadyForNextShot){
                ReadyForNextShot = Time.time + 1/fireRate;
                Shoot();
            }
        }
    }

    void FaceMouse()
    {
        // Check if the mouse passes the horizontale Linie of the player. If yes, flip the gun
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePosition.x > transform.position.x && !facingRight)
        {
            FlipGun();
        }
        else if (mousePosition.x < transform.position.x && facingRight)
        {
            FlipGun();
        }

        // Rotate Weapon towards the mouse
        Gun.transform.right = direction;
    }


    //Flip the gun horizontally
    private void FlipGun()
    {
        facingRight = !facingRight;
        Vector3 scale = Gun.localScale;
        scale.y *= -1;  
        Gun.localScale = scale;
    }

    //Shoot the bullet
    void Shoot(){
        GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
        //Rigidbody2D bulletRigidbody = Bullet.GetComponent<Rigidbody2D>();
        BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * bulletSpeed);

        //Play the shooting animation
        GunAnimator.SetTrigger("Shoot");

        //Shake the camera
        CameraShaker.Instance.ShakeOnce(1.2f, 0.8f, 0.1f, 0.15f);

        //Destroy the bullet after 1.5 seconds (bullet lifetime)        
        Destroy(BulletIns, 1.5f);
    }



}