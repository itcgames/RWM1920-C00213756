using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalExit : MonoBehaviour
{
    private void Update()
    {
        if(GameObject.Find("PortalEntrance"))
        {
        }
        else
        {
            Destroy(gameObject);
        }
    }

}

