using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEntrance : MonoBehaviour
{
    GameObject Player;
    GameObject PortalExit;
    Transform PortalExitGate;
    [Header("Name Of Objects Related")]
    public string PortalExitName;
    public string EntityToTeleport;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find(EntityToTeleport);
        PortalExit = GameObject.Find(PortalExitName);

        PortalExitGate = PortalExit.transform.Find("Portal");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(TeleportPlayer());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
    IEnumerator TeleportPlayer()
    {
        yield return new WaitForSeconds(0.25f);
        Player.transform.position = new Vector2(PortalExitGate.transform.position.x, Player.transform.position.y);
    }


}
