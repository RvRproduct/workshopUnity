using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseCollectible : MonoBehaviour
{
    protected int onHitOutcome = 10;
    public virtual void OnHitAction()
    {
        Debug.Log("Hello from Base class");
    }

    protected void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnHitAction();
        } 
    }
}
