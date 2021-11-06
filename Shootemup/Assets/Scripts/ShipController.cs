using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    Rigidbody2D rb2d;
    GameObject a,b;
    public GameObject bullet;
    public float speed = 8;
    private float horizontalMovement;
    private float verticalMovement;
    public int hp=3;
    public int delay=0;

    void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
        a=transform.Find("a").gameObject;
        b=transform.Find("b").gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.Space)&&delay>50){
            Shoot();

        }
        delay++;
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

    void Shoot(){
        delay=0;
        Instantiate(bullet, a.transform.position,Quaternion.identity);
        Instantiate(bullet, b.transform.position,Quaternion.identity);
    }
}
