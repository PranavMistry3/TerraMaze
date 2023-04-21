using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{

    private CharacterController charControl;
    public float speed = 6.0f;

    private float mouseSensitivity = 2.0f;
    public AudioSource runningSound;


    // Start is called before the first frame update
    void Start()
    {
        
        charControl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            runningSound.enabled = true;
        }
        else
        {
            runningSound.enabled = false;
        }
    }

    private void Move()
    {
        
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * vert + transform.right * horiz;
        
        // Debug.Log("abc" + horiz);
       // GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(runningSound);
        charControl.Move(move);

           
    }

    private void Rotate()
    {
        float horiz = Input.GetAxis("Horizontal");

        transform.Rotate(0, horiz * mouseSensitivity, 0);
    }
}
