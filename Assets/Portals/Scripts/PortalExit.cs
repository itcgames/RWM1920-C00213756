using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalExit : MonoBehaviour
{
    // Start is called before the first frame update

    public int ExitNumber = 0;

    void Start()
    {
        gameObject.name = "PExit" + ExitNumber.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
