using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb;
    public float xSpeed;
    public float ySpeed;

    public bool canShoot;
    public float fireRate;
    public float hp;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(xSpeed, ySpeed*-1);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="Players"){
            other.gameObject.GetComponent<ShipController>().Damage();
            Die();
        }
    }

    void Die(){
        Destroy(gameObject);
    }

    public void Damage(){
        hp--;
        if(hp==0){
            Destroy(gameObject);
        }
    }
}
