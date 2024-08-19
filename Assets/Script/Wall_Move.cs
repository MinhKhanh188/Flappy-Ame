using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Move : MonoBehaviour
{
    // Start is called before the first frame update
private GameObject obj;
    private Vector3 oldPosition;

    public float moveRange;
    public float moveSpeed;
    public float minY;
    public float maxY;

    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        oldPosition = obj.transform.position;
        moveSpeed = 2; // You can set this in the Inspector if needed.
        minY = -1;   // You can set this in the Inspector if needed.
        maxY = 1;    // You can set this in the Inspector if needed.
    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, 0, 0)); // Adjust the x-coordinate
        if (Vector3.Distance(oldPosition, obj.transform.position) > moveRange)
        {
            obj.transform.position = oldPosition;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        float randomY = Random.Range(minY, maxY); // Corrected syntax here.
        obj.transform.position = new Vector3(oldPosition.x, randomY, oldPosition.z); // Adjust the y-coordinate.
    }
}
