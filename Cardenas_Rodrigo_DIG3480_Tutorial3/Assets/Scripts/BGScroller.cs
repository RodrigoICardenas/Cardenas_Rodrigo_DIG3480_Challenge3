using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour 
{

    public float scrollSpeed;
    public float tileSizeZ;
    public GameController gameController;
    public float speed;

    private Vector3 startPosition;

    void Start () 
    {
        startPosition = transform.position;
        speed = 50;
    }

    void Update ()
    {
        if (gameController.TimeAttack == false)
        {
            if (gameController.score>=100)
            {
            float newPosition = Mathf.Repeat (Time.time * (100*scrollSpeed), tileSizeZ);
            transform.position = startPosition + Vector3.forward * newPosition;
            }

            else
            {
                float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
                transform.position = startPosition + Vector3.forward * newPosition;
            }
        }
        else
        {
        float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
        }
    }
}