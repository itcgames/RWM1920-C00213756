using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TestSuite
{

    GameObject Entrance = Resources.Load("PortalEntrance") as GameObject;
    GameObject Exit = Resources.Load("PortalExit") as GameObject;
    GameObject Player = Resources.Load("Player") as GameObject;


    [UnityTest]
    public IEnumerator isPortalEntranceNotNull()
    {

        Assert.IsNotNull(Entrance);

        yield return null;
    }

    [UnityTest]
    public IEnumerator isPortalExitNotNull()
    {

        Assert.IsNotNull(Exit);

        yield return null;
    }

    [UnityTest]
    public IEnumerator arePortalsConnected()
    {
        Entrance.GetComponent<PortalEntrance>().connectedTeleporter = Exit.gameObject;

        Assert.IsNotNull(Entrance.GetComponent<PortalEntrance>().connectedTeleporter);

        yield return null;
    }

    [UnityTest]
    public IEnumerator Teleport()
    {

        Entrance.transform.position = new Vector2(0, 0);
        Exit.transform.position = new Vector2(10, 10);

        Player.transform.position = new Vector2(0, 0);

        Vector2 tempPos = Player.transform.position;

        Entrance.GetComponent<PortalEntrance>().TeleportPlayer(Player);


        yield return new WaitForSeconds(6);

        Assert.AreNotEqual(Player.transform.position, tempPos);

    }
}

