using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DsableParticle : MonoBehaviour
{
    private ParticleSystem ps;
    private bool dis = true;
    // Start is called before the first frame update
    void Start()
    {
        ps = gameObject.GetComponent<ParticleSystem>();

    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Player" && dis)
        {
            ps.Play();
            dis = false;
        }
    }
}
