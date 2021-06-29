using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLeap : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {

        this.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
    }
}
