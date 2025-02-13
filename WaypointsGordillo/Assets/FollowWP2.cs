using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP2 : MonoBehaviour
{
    Transform goal;
    float speed = 5.0f;
    float accuracy = 5.0f;
    float rotSpeed = 2.0f;

    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;
    int currentWP = 0;
    Graph g;

    void Start()
    {
        wps = wpManager.GetComponent<WPManager>().waypoints;
        g = wpManager.GetComponent<WPManager>().graph;
        currentNode = wps[0];

        Invoke("GoToRuin", 2);
    }

    public void GoToHeli()
    {
        g.AStar(currentNode, wps[0]);
        currentWP = 0;
    }

    public void GoToRuin()
    {
        g.AStar(currentWP, wps[5]);
        currentWP = 5;
    }

    void LateUpdate()
    {
        if (g.pathList.Count == 0 || currentWP  == g.pathList.Count) { return; }

        if (Vector3.Distance(g.pathList[currentWP].getID().transform.position, this.transform.position) < accuracy)
        {
            currentWP++;
        }

        if (currentWP == g.pathList.Count -)
    }
}
