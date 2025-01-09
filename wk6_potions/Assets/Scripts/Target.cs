using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms.Impl;

[RequireComponent(typeof(Rigidbody2D))]

public class Target : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 randomForce, randomTorque;
    float xRange = 4;
    float ySpawn = -1.2f;
    private GameManager gameManagerScript;
    [SerializeField] int pointValue;
    public ParticleSystem explosionParticle;
    
    public AudioClip clickSound;
    private AudioSource audioSource;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        
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
        audioSource.PlayOneShot(clickSound);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {        
        if(gameObject.CompareTag("Good"))
        {
            gameManagerScript.UpdateScore(pointValue, 0);
        } else if(gameObject.CompareTag("Bad"))
        {
            gameManagerScript.UpdateScore(0, pointValue);
        }
        
        if(other.gameObject.CompareTag("Cauldron"))
        {
            Destroy(gameObject);
        }
    }
 
}
