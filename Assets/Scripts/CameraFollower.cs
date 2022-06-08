using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform penguin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (penguin.position.y > transform.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x, penguin.position.y, transform.position.z);
            transform.position = newPos;
        }
        else if (penguin.position.y < transform.position.y - 4)
        {
            Vector3 newPos = new Vector3(transform.position.x, penguin.position.y + 4, transform.position.z);
            transform.position = newPos;
        }
    }
}
