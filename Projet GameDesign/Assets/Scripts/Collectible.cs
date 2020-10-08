using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : Interactable
{
    public override void Interact()
    {
        LightUp();
    }

    private void LightUp()
    {
        Destroy(gameObject);
        //declare public something "light"
        //increase the radius of the light if < x
    }
}
