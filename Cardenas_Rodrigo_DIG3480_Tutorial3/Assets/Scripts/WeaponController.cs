using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour 
{

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;

    public AudioSource musicSource;
    public AudioClip musicClipOne;

    void Start ()
    {
        musicSource.clip = musicClipOne;
        InvokeRepeating ("Fire", delay, fireRate);
    }

    void Fire ()
    {
        Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
        musicSource.Play ();
    }
}