using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hareket : MonoBehaviour
{   
    public float eklenenaci;
    float egim = 45f;
    public GameManager managergame;
      bool oyunbitti = true;
   
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
        Vector3 position = this.transform.position;
        

        if (egim<=-45)
        {
            position.x += 0.005f;
            position.y -= 0.005f;
            this.transform.position = position;
        }
        if(egim>=45)
        {
            position.x += 0.005f;
            position.y += 0.005f;
            this.transform.position = position;
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
        SceneManager.LoadScene(0);
    }








}
