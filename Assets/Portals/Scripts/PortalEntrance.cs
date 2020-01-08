using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEntrance : MonoBehaviour
{
    GameObject Player;
    GameObject PortalExit;
    [Header("Properties")]
    public float TeleportTime = 1.0f;

    public AudioSource teleporting;

    [Header("Name Of Objects Related")]

    public string EntityToTeleport;

    [Header("Connected Teleporter")]
    public int EntranceNumber = 0;

    Vector2 speedBefore = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "PEntrance" + EntranceNumber.ToString();
        Player = GameObject.Find(EntityToTeleport);


        PortalExit = GameObject.Find("PExit" + EntranceNumber.ToString());
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            speedBefore = Player.GetComponent<Rigidbody2D>().velocity;
            Player.SetActive(false);
            StartCoroutine(TeleportPlayer());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
    IEnumerator TeleportPlayer()
    {
        yield return new WaitForSeconds(TeleportTime);
        Player.SetActive(true);

        Player.transform.position = new Vector2(PortalExit.transform.position.x, PortalExit.transform.position.y);
        Player.GetComponent<Rigidbody2D>().velocity = speedBefore;

    }

    private void Update()
    {
        if(Player.activeSelf != true)
        {
            teleporting.Play();
        }
        else
        {
            teleporting.Stop();
        }
    }
}
