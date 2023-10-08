using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_move : MonoBehaviour
{
    public float hAmplitude = 0.1f;
    public float hFrequency = 0.8f;

    Vector3 hPosOrigin = new Vector3();
    Vector3 hTempPos = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        hPosOrigin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        hTempPos = hPosOrigin;
        hTempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * hFrequency) * hAmplitude;
        transform.position = hTempPos;
    }
}
