using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Animations;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;
using TMPro;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    public RigBuilder rig;
    bool built = false;
    public TwoBoneIKConstraint leftHand;
    public TwoBoneIKConstraint rightHand;
    public float movementSpeed;
    public float rotationSpeed;
    public Camera cam;
    public GameObject body;
    public Animator anim;
    
    

    public float InteractionRadius;
    [Header("Quests")]
    public float PresentsCollected;
    public LayerMask PresentLayer;

    [Header("UI")]
    public GameObject InteractObject;
    public TMP_Text InteractText;
    // Start is called before the first frame update
    void Start()
    {
        rig.Build();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        built = false;
        StartCoroutine(BuildRig());
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = cam.transform.forward * moveVertical + cam.transform.right * moveHorizontal;
        movement.y = 0; // keep the player on the ground

        transform.Translate (movement * movementSpeed * Time.deltaTime, Space.World);

        if (movement != Vector3.zero){
            transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (movement.normalized), rotationSpeed);
        }
        if(Input.GetKey(KeyCode.LeftShift)){
            movementSpeed = 5;
        }else{
            movementSpeed = 3;
        }
        InteractObject.SetActive(false);
        Collider[] hitColliders = Physics.OverlapSphere(body.transform.position, InteractionRadius, PresentLayer);
        foreach (var hitCollider in hitColliders)
        {
            if(hitCollider.gameObject.tag == "Present"){
                InteractObject.SetActive(true);
                InteractText.text = "Press E to pick up";
                if(Input.GetKeyDown(KeyCode.E)){
                    Destroy(hitCollider.gameObject);
                    PresentsCollected += 1;
                }
            }
        }
    }  
    IEnumerator BuildRig(){
        yield return new WaitForSeconds(1);
        rig.Build();
    }
    public void buildRig(){
        if(built)return;
        rig.Build();
        built = true;
    }

}

