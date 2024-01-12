using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollide : MonoBehaviour
{
   public string hitText = "Obiect țintă lovit!";
    private bool isTargetHit = false; // A fost lovită deja această țintă?

    // Funcția apelată atunci când are loc o coliziune
    private void OnCollisionEnter(Collision collision)
    {
        // Verificați dacă obiectul care a lovit este etichetat ca "dagger"
        if (collision.gameObject.CompareTag("dagger") && !isTargetHit)
        {
            // Afișați textul
            Debug.Log(hitText);
            ScoreManager.instance.AddScore(1);
            isTargetHit = true;
            // Puteți adăuga aici orice altă logică dorită, cum ar fi schimbarea culorii sau distrugerea obiectului țintă
        }
    }
}
