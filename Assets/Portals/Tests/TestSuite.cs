using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TestSuite
{
    [UnityTest]
    public IEnumerator isActve()
    {
        GameObject Entrance = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Portals/Prefabs/PortalEntrance"));

        Assert.IsNotNull(Entrance);

        yield return null;
    }

}

