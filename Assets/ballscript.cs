using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballscript : MonoBehaviour
{
    public int speed = 30;
    public Rigidbody2D sesuatu;
    public Animator animatr;
    // Start is called before the first frame update
    void Start()
    {
        sesuatu.velocity = new Vector2(-1, -1) * speed;
        animatr.SetBool("isMove",true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(sesuatu.velocity.x > 0 ){//bola ke kanan
           sesuatu.GetComponent<Transform>().localScale = new Vector3(1,1,1);
        }else{
            sesuatu.GetComponent<Transform>().localScale = new Vector3(-1,1,1);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.name=="WallRight" || other.collider.name=="WallLeft"){
            StartCoroutine(wait());
        }
    }
    IEnumerator wait(){
        sesuatu.velocity = Vector2.zero;
        animatr.SetBool("isMove",false);
        sesuatu.GetComponent<Transform>().position = new Vector2(8,0);
        yield return new WaitForSeconds(1);
        sesuatu.velocity = new Vector2(-1, -1) * speed;
        animatr.SetBool("isMove",true);

        
        
}
}
