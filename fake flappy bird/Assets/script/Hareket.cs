using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hareket : MonoBehaviour
{   
    public float eklenenaci;
    float egim = 45f;
    public GameManager managergame;
    bool oyunbitti = true;
   
  
    public GameObject GameOverScreen;
   
   
    private void Start()
    {
        
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, egim);
     
    }

    void Update()
    {
        if (oyunbitti == true)
        {
            fırsttransform();
            if (egim <= -45)
            {

                eklenenaci = 90f;

            }
            else if (egim >= 45)
            {
                eklenenaci = -90f;
            }
            if (Input.GetMouseButtonDown(0))
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, egim + eklenenaci);
                egim = egim + eklenenaci;
            }
        }
    }
    private void fırsttransform()
    {
       
        

        if (egim<=-45)
        {
           
           transform.position += new Vector3(1.6f, -1.6f, 0) * Time.deltaTime;
        }
        if(egim>=45)
        {
         
            transform.position += new Vector3(1.6f, 1.6f, 0) * Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag== "SkorAlani")
        {
            managergame.UpdateScore();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        oyunbitti = false;
        GameOverScreen.SetActive(true);
    }








}
