using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    int dir=1;
    Rigidbody2D rb;
    
    void Awake() {
        rb=GetComponent<Rigidbody2D>();
    }
    public void ChangeDirection()
    {
        dir*=-1;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity=new Vector2(0,12*dir);
    }

    void OnTriggerEnter2D(Collider2D other) {

        if(dir==1){
            if(other.gameObject.tag=="Enemy"){
                other.gameObject.GetComponent<EnemyController>().Damage();
                Destroy(gameObject);
            }
        }
        else{
            if(other.gameObject.tag=="Players"){
                other.gameObject.GetComponent<EnemyController>().Damage();
                Destroy(gameObject);
            }
        }
    }
}
