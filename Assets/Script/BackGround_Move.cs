using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Move : MonoBehaviour
{
   private GameObject obj;
    private Vector3 oldPosition;

    public float moveRange;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        oldPosition = obj.transform.position;
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
}
