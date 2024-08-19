using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorsMove : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Adjust the speed as needed
    public float maxY = 5.0f; // Adjust the maximum Y position
    public float minY = -5.0f; // Adjust the minimum Y position

    private int direction = 1; // 1 for moving up, -1 for moving down

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move the meteor up and down
        transform.Translate(Vector3.up * direction * moveSpeed * Time.deltaTime);

        // Check if the meteor has reached the maximum or minimum Y position
        if (transform.position.y >= maxY)
        {
            direction = -1; // Change direction to move down
        }
        else if (transform.position.y <= minY)
        {
            direction = 1; // Change direction to move up
        }
    }
}
