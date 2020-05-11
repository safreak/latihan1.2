using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballscript : MonoBehaviour
{
    //public int speed = 30;
    public Rigidbody2D sesuatu;
    public Animator animatr;
    public AudioSource hitEffect;
    // Start is called before the first frame update
    void Start()
    {
        int x = Random.Range(0 , 2)*2 -1;
        int y = Random.Range(0 , 2)*2 -1;
        int speed = Random.Range(20,26);
        sesuatu.velocity = new Vector2(x,y) * speed;
        sesuatu.GetComponent<Transform>().position = Vector2.zero;
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
        if(other.collider.tag=="Player"){
            hitEffect.Play();
        }
    }
    IEnumerator wait(){
        
        sesuatu.velocity = Vector2.zero;
        animatr.SetBool("isMove",false);
        sesuatu.GetComponent<Transform>().position = Vector2.zero;

        yield return new WaitForSeconds(1);

        int x = Random.Range(0 , 2)*2 -1;
        int y = Random.Range(0 , 2)*2 -1;
        int speed = Random.Range(20,26);
        sesuatu.velocity = new Vector2(x,y) * speed;
        animatr.SetBool("isMove",true);

        
        
}
}
