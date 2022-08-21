using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureAction : MonoBehaviour
{
    System.Random rnd = new System.Random();
    bool visible = true;
    bool treasureFound = false;
    Renderer renderer;
    void Start()
    {
        var rndX = rnd.Next(-215, 150);
        var rndZ = rnd.Next(325, 390);
        var startingPos = new Vector3(rndX, 30, rndZ);
        transform.position = startingPos;
        renderer = GetComponent<Renderer>();
    }
    void Update()
    {
        if(treasureFound){
            renderer.enabled = true;
        } else {
            renderer.enabled = visible;
        }
        if (Input.GetKeyUp(KeyCode.V))
        {
            visible = !visible;
            Debug.Log("Visibility: " + visible);
        }
        Utilities util = new Utilities();
        treasureFound = util.checkIfPirateFoundTreasure(transform.position);
    }
}
