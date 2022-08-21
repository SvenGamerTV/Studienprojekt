using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities
{
    bool treasureFound = false;
    public bool checkIfPirateFoundTreasure(Vector3 pTreasurePos){
        GameObject[] pirates = GameObject.FindGameObjectsWithTag("Pirate");
        foreach (GameObject pirate in pirates)
        {
            RandomMovement rm = (RandomMovement)pirate.GetComponent(typeof(RandomMovement));
            Vector3 posPirate = pirate.transform.position;
            var dist = Vector3.Distance(posPirate, pTreasurePos);
            if(dist < 40){
                rm.moveToTreasure(pTreasurePos);
                treasureFound = true;
            }
        }
        if(treasureFound){
            foreach(GameObject pirate in pirates){
                RandomMovement rm = (RandomMovement)pirate.GetComponent(typeof(RandomMovement));
                rm.moveToTreasure(pTreasurePos);
            }
            return true;
        }
        return false;
    }
}
