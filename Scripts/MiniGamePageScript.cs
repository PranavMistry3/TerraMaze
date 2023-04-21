using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamePageScript : MonoBehaviour
{
    public GameObject fembot;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            fembot.GetComponent<Animator>().SetTrigger("runningtrigger");
        }
        if (Input.GetKey(KeyCode.Space))
        {
            fembot.GetComponent<Animator>().SetTrigger("jumpingtrigger");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

}
