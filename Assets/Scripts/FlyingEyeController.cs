using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlyingEyeController : MonstersScript
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FlyingEyeController A = new FlyingEyeController();
        A.Attack();
    }
    
    
}
