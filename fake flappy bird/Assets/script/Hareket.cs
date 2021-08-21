using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hareket : MonoBehaviour
{   
   
    public GameManager managergame;
    bool isCountinueGame = true;
    private bool isLookup = true;
    [Tooltip("aşağıya doğru bakan sprite sürüklensin")]
    public SpriteRenderer lookDown;
    public SpriteRenderer lookUp;

    public GameObject GameOverScreen;
   
   
    private void Start()
    {
        
        ChangeAngle();
    }

    void Update()
    {
        if (isCountinueGame == true)
        {
            fırsttransform();

            if (Input.GetMouseButtonDown(0))
            {
               
                ChangeAngle();
            }
        }
    }
    private void fırsttransform()
    {
        if (isLookup)
        {
            transform.position += new Vector3(1.6f, 1.6f, 0) * Time.deltaTime;
            return;
        }
        
        transform.position += new Vector3(1.6f, -1.6f, 0) * Time.deltaTime;     
    }
   
   /// <summary>
   /// açıyı değiştirir.
   /// </summary>
    public void ChangeAngle()
    {
        isLookup = !isLookup;
        lookUp.enabled = isLookup;
        lookDown.enabled = !isLookup;
     

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

       
     managergame.UpdateScore();
     }
    private void OnCollisionEnter2D(Collision2D other)
    {
        isCountinueGame = false;
        GameOverScreen.SetActive(true);
    }
    /// <summary>
    /// personel eklenir
    /// </summary>
    /// <param name="ad">personelin adını giriniz</param>
    /// <param name="personelin soyadı"></param>
    public void SetPersonel(string ad,string soyad)
    {

    }








}
