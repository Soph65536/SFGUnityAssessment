using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralCluckAnimator : MonoBehaviour
{
    Animator Animator;

    public bool isTalking = false;
    public bool Glitching = false;

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    void Update(){
        Animator.SetBool("isTalking", isTalking);
        Animator.SetBool("Glitching", Glitching);
    }
}
