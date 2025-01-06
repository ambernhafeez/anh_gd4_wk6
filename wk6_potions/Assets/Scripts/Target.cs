using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms.Impl;

[RequireComponent(typeof(Rigidbody2D))]

public class Target : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 randomForce, randomTorque;
    float xRange = 4;
    float ySpawn = -1.4f;
    private GameManager gameManagerScript;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // add a random upwards force
        rb.AddForce(Vector3.up * Random.Range(randomForce.x, randomForce.y), ForceMode2D.Impulse);
        
        // add a random rotation/torque
        rb.AddTorque(Random.Range(randomTorque.x, randomTorque.y), ForceMode2D.Impulse);
        
        // random starting position
        transform.position = new Vector3(Random.Range(-xRange, xRange), ySpawn, 0);

        // get access to score
        gameManagerScript = (GameManager)FindAnyObjectByType(typeof(GameManager));
    }
    
    void Update() 
    {
        
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {        
        if(gameObject.CompareTag("Good"))
        {
            gameManagerScript.score += 1;
            Debug.Log("Score = " + gameManagerScript.score);
        } else if(gameObject.CompareTag("Bad"))
        {
            gameManagerScript.lives -= 1;
        }
        
        if(other.gameObject.CompareTag("Cauldron"))
        {
            Destroy(gameObject);
        }
    }
 
}
