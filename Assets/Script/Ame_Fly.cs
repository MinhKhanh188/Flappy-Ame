using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ame_Fly : MonoBehaviour
{
    public float flyPower;
    private GameObject obj;
    GameObject GameController;
    private Rigidbody2D rb;

    public AudioClip flyCLip;
    public AudioClip gameOverClip;

    public AudioSource CatMuse;

    private AudioSource audioSource;

    public List<AudioClip> characterSounds;

    public List<AudioClip> deadSounds;

    private bool isDead = false; // Track if the player is dead

    void Start()
    {
        obj = gameObject;
        audioSource = obj.GetComponent<AudioSource>();
        audioSource.clip = flyCLip;
        rb = obj.GetComponent<Rigidbody2D>();
        flyPower = 550;

        if (GameController == null)
            GameController = GameObject.FindGameObjectWithTag("GameController");
    }

    void Update()
    {
        if (!isDead) // Only allow flying if the player is not dead
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Fly");
                rb.AddForce(new Vector2(0, flyPower));

                int randomSoundIndex = Random.Range(0, characterSounds.Count);
                audioSource.clip = characterSounds[randomSoundIndex];
                audioSource.Play();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDead)
        {
            EndGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isDead)
        {
            GameController.GetComponent<GameController>().getPoint();
            if (other.gameObject.tag == "CatMusic")
            {
                CatMuse.Play();
            }
        }
    }

    void EndGame()
    {
        isDead = true; // Set the player as dead
        StartCoroutine(PlayDeadSoundAndEndGame());
    }

    private IEnumerator PlayDeadSoundAndEndGame()
    {
        int randomSoundIndex = Random.Range(0, deadSounds.Count);
        audioSource.clip = deadSounds[randomSoundIndex];
        audioSource.Play();

        yield return new WaitForSeconds(2f); // Delay for 2 seconds

        GameController.GetComponent<GameController>().EndGame();
    }
}
