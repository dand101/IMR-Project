using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainCollide : MonoBehaviour
{
    public string hitText = "Obiect țintă lovit!";
    public GameObject keyPrefab;
    public int keyIndex;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            // Display hit text if needed
            // Debug.Log(hitText);
            InstantiateKeyPrefab();
            
            Destroy(gameObject);
        }
    }

    void InstantiateKeyPrefab()
    {
        if (keyIndex == null)
        {
            keyIndex = 1000;
        }

        if (keyPrefab != null)
        {
            GameObject keyObj = Instantiate(keyPrefab, transform.position, Quaternion.identity);
            Key keyScript = keyObj.GetComponent<Key>();
            if (keyScript != null)
            {
                keyScript.keyNumber = keyIndex; 
            }
            else
            {
                Debug.LogError("Key script not found on the key prefab.");
            }
        }
        else
        {
            Debug.LogError("Key prefab is not assigned in the inspector.");
        }
    }
}
