using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string promptMsg;
    public void baseInteract()
    {
        Interact();
    }
    protected virtual void Interact()
    {

    }
}
