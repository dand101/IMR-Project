using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TMP_Text scoreText;
    public GameObject keyPrefab;
    public GameObject spawnKeyLocation;

    private int score = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int value)
    {
        score += value;
        if (scoreText != null)
        {
            scoreText.text = "Targets hit: " + score;
        }
        if (score >= 3 && keyPrefab != null)
        {
            SpawnKey();
        }

    }
    void SpawnKey()
    {
        GameObject key = Instantiate(keyPrefab, spawnKeyLocation.transform.position, Quaternion.identity);

        Key keyScript = key.GetComponent<Key>();

        if (keyScript != null)
        {

            keyScript.keyNumber = 3;
        }
    }


}
