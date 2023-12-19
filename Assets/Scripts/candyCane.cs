using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candyCane : MonoBehaviour
{
    public bool Active;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!Active)return;
        if(Input.GetMouseButtonDown(0)){
            anim.SetTrigger("Swing");
        }
    }
}
