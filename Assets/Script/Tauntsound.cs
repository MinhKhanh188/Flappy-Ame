using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tauntsound : MonoBehaviour
{
    private AudioSource audioSource;

    public List<AudioClip> tauntingSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Initialize the audio source
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha4))
        {
            // Check if the number 3 key is pressed

            // Play the taunting sound
            int randomSoundIndex = Random.Range(0, tauntingSound.Count);
            audioSource.clip = tauntingSound[randomSoundIndex];
            audioSource.Play();
        }
    }
}
