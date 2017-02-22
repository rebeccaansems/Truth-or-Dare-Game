using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITransistion : MonoBehaviour
{
    private Animator anim;

    void Awake()
    {
        anim = this.GetComponent<Animator>();
    }

    public void TransIn()
    {
        anim.SetInteger("Transition", 1);
    }

    public void TransOut()
    {
        anim.SetInteger("Transition", 2);
    }

    public void TransInQuestion()
    {
        anim.SetInteger("Transition", 3);
    }

    public void TransOutQuestion()
    {
        anim.SetInteger("Transition", 4);
    }
}
