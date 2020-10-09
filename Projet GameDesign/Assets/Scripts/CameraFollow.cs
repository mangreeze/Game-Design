using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public Vector2 maxBounds;
    public Vector2 minBounds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = player.position.x + offset.x;
        float y = player.position.y + offset.y;

        if (x > maxBounds.x)
            x = maxBounds.x;
        else if (x < minBounds.x)
            x = minBounds.x;
        if (y > maxBounds.y)
            y = maxBounds.y;
        else if (y < minBounds.y)
            y = minBounds.y;

        transform.position = new Vector3(x, y, offset.z);
    }
}
