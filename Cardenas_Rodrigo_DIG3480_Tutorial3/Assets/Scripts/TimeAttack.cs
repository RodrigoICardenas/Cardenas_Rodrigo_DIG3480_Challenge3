using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAttack : MonoBehaviour
{
    public GameController gamecontroller;
    public float interval;
    public GameObject playerExplosion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gamecontroller.TimeAttack == true)
        {
            if (interval > 0)
            {
                interval -= Time.deltaTime;
            }
            else
            {
                enabled = false;
                Instantiate(playerExplosion, transform.position, transform.rotation);
                Destroy(gameObject);
                gamecontroller.GameOver ();                
            }
        }
    }
}
