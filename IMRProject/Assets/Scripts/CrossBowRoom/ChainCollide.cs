using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainCollide : MonoBehaviour
{
   public string hitText = "Obiect țintă lovit!";

    // Funcția apelată atunci când are loc o coliziune
    private void OnCollisionEnter(Collision collision)
    {
        // Verificați dacă obiectul care a lovit este etichetat ca "dagger"
        if (collision.gameObject.CompareTag("Weapon") )
        {
            // Afișați textul
            Debug.Log(hitText);
            Destroy(gameObject);

            // Puteți adăuga aici orice altă logică dorită, cum ar fi schimbarea culorii sau distrugerea obiectului țintă
        }
    }
}
