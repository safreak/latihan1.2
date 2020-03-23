using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballscript : MonoBehaviour
{
    public int speed = 30;
    public Rigidbody2D sesuatu;
    // Start is called before the first frame update
    void Start()
    {
        sesuatu.velocity = new Vector2(-1, -1) * speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.name=="WallRight" || other.collider.name=="WallLeft"){
            GetComponent<Transform>().position = new Vector2(0,0);
        }
    }
}
