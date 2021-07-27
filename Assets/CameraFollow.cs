using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 offset;
    public Vector2 minPos, maxPos;
    public bool bound;
    public PlayerController player;
    private Vector2 velocity;
    public float SmoothTimeX, SmoothTimeY;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float PosX = Mathf.SmoothDamp(this.transform.position.x, player.transform.position.x, ref velocity.x, SmoothTimeX);
        float PosY = Mathf.SmoothDamp(this.transform.position.y, player.transform.position.y, ref velocity.y, SmoothTimeY);
        transform.position = new Vector3(PosX, PosY, transform.position.z);
        if (bound)
        {
            transform.position = new Vector3
            (
                Mathf.Clamp(transform.position.x, minPos.x, maxPos.x),
                Mathf.Clamp(transform.position.y, minPos.y, maxPos.y),
                Mathf.Clamp(transform.position.z, transform.position.z, transform.position.z)
            );
        }
    }
}
