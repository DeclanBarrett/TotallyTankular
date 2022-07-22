using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAfter : MonoBehaviour
{
    public float deathTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, deathTime);
    }

}
