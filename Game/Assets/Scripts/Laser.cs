using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Laser a;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (a.transform.position.x > 10)
        {
            Destroy(a.gameObject);
        }
        this.transform.position += new Vector3(0.2f, 0, 0);
    }
}