using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    System.Random rnd = new System.Random();
    //Array für bereits besuchte Postionen
    List<Vector3> visitedPositions = new List<Vector3>();
    bool positionValid = false;
    bool treasureFound = false;

    int counter = 0;

    void Start()//Awake()
    {
        var startingPos = new Vector3(0,0,0);
        if(gameObject.name == "Pirate1"){
            var mr = GetComponent<Renderer>();
            mr.material.color = new Color(1f, 0f, 1f, 1f);
            startingPos = new Vector3(139.6f, 30, 454f);
        } else if(gameObject.name == "Pirate2"){
            var mr = GetComponent<Renderer>();
            mr.material.color = new Color(0f, 1f, 0f, 1f);
            startingPos = new Vector3(-237f, 30, 454f);
        } else if(gameObject.name =="Pirate3"){
            var mr = GetComponent<Renderer>();
            mr.material.color = new Color(1f, 0f, 0f, 1f);
            startingPos = new Vector3(-40f, 30, 336f);
        } else if(gameObject.name == "Pirate4"){
            var mr = GetComponent<Renderer>();
            mr.material.color = new Color(0f, 0f, 1f, 1f);
            startingPos = new Vector3(61f, 30, 573f);
        }
        //Bestimmen um welchen Pirat es sich handelt
        //Start-Koordinaten random setzen
        transform.position =  startingPos;
        Debug.Log("Startposition set to: " + transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        if(!treasureFound){
            counter++;
            if(counter == 750){
                positionValid = false;
                //In irgendeine Richtung für eine bestimmte Länge bewegen
                    //wenn Position bereits vorhanden neu generieren
                while(!positionValid){
                    var pos = transform.position;
                    Debug.Log("Position: " + pos);
                    var rndMoveX = rnd.Next(-20, 20);
                    var rndMoveZ = rnd.Next(-20,20);
                    Debug.Log("VecX: " + pos.x + " VecY: " + pos.y + " VecZ: " + pos.z);
                    var newX = pos.x + rndMoveX;
                    var newZ = pos.z + rndMoveZ;
                    var newPos = new Vector3(newX, 30, newZ);
                    //Wurde Position bereits besucht?
                    if(!visitedPositions.Contains(newPos)){
                        //Ist Position noch auf der Insel?
                        if(newPos.z > 275 && newPos.z < 740){
                            if(newPos.x > -265 && newPos.x < 200){
                                //Postion speichern
                                visitedPositions.Add(newPos);
                                transform.position = newPos;
                                positionValid = true;
                            }
                        }
                    }
                }
                counter = 0;
                //Abfrage ob Schatz in der Nähe
                    //wenn ja zu Position bewegen
                
            }
        }
    }

    public void moveToTreasure(Vector3 pTreasurePos){
        treasureFound = true;
        transform.position = pTreasurePos;
    }
}
