using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score, lives;
    public List<GameObject> targets;
    public bool isGameOver; 
    public TMP_Text scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnObjects());
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "" + score;
    }

    IEnumerator spawnObjects()
    {
        while(!isGameOver)
        {
            // pick a random object to spawn 
            int spawnIndex = Random.Range(0, targets.Count);
            // spawn object
            Instantiate(targets[spawnIndex]);
            // wait for seconds
            float randomWaitTime = Random.Range(0.5f, 2);
            yield return new WaitForSeconds(randomWaitTime);
        }
    }
}
