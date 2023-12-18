using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Animations;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;

public class PlayerMovement : MonoBehaviour
{
    public RigBuilder rig;
    public TwoBoneIKConstraint leftHand;
    public TwoBoneIKConstraint rightHand;
    // Start is called before the first frame update
    void Start()
    {
        rig.Build();
    }

    // Update is called once per frame
    void Update()
    {
        rig.Build();
    }
}
