using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;
using Photon.Pun.UtilityScripts;
[RequireComponent(typeof(CharacterController))]
public class Player_1_Control : MonoBehaviourPunCallbacks 
{
  
    float yVelocity = 0f;
    [Range(-5f, -25f)]
    public float gravity = -15f;
    //the speed of the player movement
    [Range(5f, 50f)]
    public float movementSpeed = 10f;
    //jump speed
    [Range(5f, 50f)]
    public float jumpSpeed = 10f;

    float pitch = 0f;
    float speed = 10f;
    [Range(1f, 90f)]
    public float maxPitch = 85f;
    [Range(-1f, -90f)]
    public float minPitch = -85f;

     public Transform cameraTransform;
 
    [Range(0.5f, 10f)]
    public float mouseSensitivity = 2f;

     CharacterController cc;
 
private void Start()
    {
        cc = GetComponent<CharacterController>();
        if (!photonView.IsMine)
        {
            GetComponentInChildren<Camera>().enabled = false;
            GetComponentInChildren<AudioListener>().enabled = false;
        }
    }

 void Update()
    {
        if (photonView.IsMine)
        {
            Look();
            Move();
        }
     }

 void Look()
    {
      float xInput = Input.GetAxis("Mouse X") * mouseSensitivity;
      float yInput = Input.GetAxis("Mouse Y") * mouseSensitivity;
       transform.Rotate(0, xInput , 0);
       pitch -= yInput;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
         Quaternion rot = Quaternion.Euler(pitch, 0, 0);
        // cameraTransform.localRotation = rot;
     }

  void Move()
  {
    if (cc.enabled == false)
        {
         return;
        }
       
 Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
   input = Vector3.ClampMagnitude(input, 1f);
    Vector3 move = transform.TransformVector(input) * movementSpeed;

    if (cc.isGrounded)
     {
       yVelocity = 0;
       if (Input.GetButtonDown("Jump"))
        {
          yVelocity = jumpSpeed;
        }
        }
         yVelocity += gravity * Time.deltaTime;
         move.y = yVelocity;
         cc.Move(move * Time.deltaTime);
    }

  
}
