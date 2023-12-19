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
    public float movementSpeed;
    public float rotationSpeed;
    public Camera cam;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rig.Build();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        rig.Build();
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = cam.transform.forward * moveVertical + cam.transform.right * moveHorizontal;
        movement.y = 0; // keep the player on the ground

        transform.Translate (movement * movementSpeed * Time.deltaTime, Space.World);

        if (movement != Vector3.zero){
            transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (movement.normalized), rotationSpeed);
        }
    }   

}

