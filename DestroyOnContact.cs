﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyOnContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;

   void Start ()
   {
       GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
       if (gameControllerObject != null)
       {
           gameController = gameControllerObject.GetComponent <GameController>();
       }
       if (gameController == null)
       {
           Debug.Log ("Cannot find 'GameController' script");
       }
   } 
   void OnTriggerEnter(Collider other)
   {
       if (other.CompareTag ("Boundry") || other.CompareTag ("Enemy"))
       {
        return;
       }
       if (explosion != null)
       {
        Instantiate (explosion, transform.position, transform.rotation);
       }
       if (other.tag == "Player")
       {
        Instantiate (playerExplosion, other.transform.position, other.transform.rotation);  
        gameController.GameOver ();
       }
       
       gameController.AddScore (scoreValue);
       Destroy(other.gameObject);
       Destroy(gameObject);
   }
}
