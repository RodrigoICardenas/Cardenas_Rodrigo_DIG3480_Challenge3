using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedRaise : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ParticleSpeed (ParticleSystem ps, float defaultVelocity, float VelocityMultiplyer){
 
     ParticleSystem.MainModule main = ps.main;
 
     main.simulationSpeed = defaultVelocity * VelocityMultiplyer;
 
     Debug.Log ("Particle simSpeed : " + main.simulationSpeed);
 
 }
}
