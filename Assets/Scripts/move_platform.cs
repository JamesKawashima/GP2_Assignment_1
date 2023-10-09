using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_platform : MonoBehaviour
{
    private CharacterController controller;
    private bool change = true;
    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GetSpeed());
        transform.position += (new Vector3(GetSpeed() * Time.deltaTime, 0, 0));
    }

    public float GetSpeed()
    {
        if (transform.position.x <= 245f && change)
        {
            return 5f;
        }
        else
        {
            change = false;

            return -5f;
        }
    }
}
