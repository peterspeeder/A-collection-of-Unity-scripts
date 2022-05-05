using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleStart : MonoBehaviour
{
    public ParticleSystem runParticle;
    // Start is called before the first frame update
    void Start()
    {
        runParticle.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            runParticle.Play();
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
            {
                runParticle.Stop();
            }
    }
}
