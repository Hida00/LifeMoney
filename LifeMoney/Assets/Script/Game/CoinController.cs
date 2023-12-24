using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if(this.transform.position.y <= -6f)
            Destroy(this.gameObject);
        if(this.transform.position.z <= 89.0f)
            Destroy(this.gameObject);
    }
}
