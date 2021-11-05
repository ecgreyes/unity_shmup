using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    Rigidbody2D rb2d;
    public float speed = 8;
    private float horizontalMovement;
    private float verticalMovement;
    public int hp=3;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");
    }

    void FixedUpdate() {
        rb2d.velocity = new Vector2(horizontalMovement * speed, rb2d.velocity.y);
        rb2d.velocity = new Vector2(rb2d.velocity.x, verticalMovement * speed);
    }

    public void Damage(){
        hp--;
        if(hp==0){
            Destroy(gameObject);
        }
    }
}
