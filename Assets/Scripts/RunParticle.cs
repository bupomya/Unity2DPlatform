using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticleAnimation : ImputMoveMent
{
    
    
    void Update()
    {
        PlayParticle();
    }

    void PlayParticle()
    {
        if(isRun)
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
    }

}
