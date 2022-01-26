/****
 * Created by: Sammy Ricketts
 * Date Created: Jan 24, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Jan 26, 2022
 * 
 * Description: Spawns multiple cube prefabs into scene.
 ****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubes : MonoBehaviour
{
    /***VARIABLES***/
    public GameObject cubePrefab; //new gameobject
    public float scalingFactor = 0.95f;
    public int numberOfCubes = 0;

    public List<GameObject> gameObjectList; //list for all cubes









    // Start is called before the first frame update
    void Start()
    {
        gameObjectList = new List<GameObject>(); //Instantiates the list
    }

    // Update is called once per frame
    void Update()
    {
        numberOfCubes++; //adds to number of cubes
        GameObject gObj = Instantiate<GameObject>(cubePrefab); //instantiate the cube

        gObj.name = "Cube" + numberOfCubes; // name property of the cube

        gObj.transform.position = Random.insideUnitSphere; //random point inside a sphere radius of 1.

        Color randColor = new Color(Random.value, Random.value, Random.value);
        gObj.GetComponent<Renderer>().material.color = randColor;

        gameObjectList.Add(gObj); //add cube to list

        List<GameObject> removeList = new List<GameObject>(); // list of game objects to remove

        foreach(GameObject goTemp in gameObjectList)
        {
            float scale = goTemp.transform.localScale.x; //record starting scale
            scale *= scalingFactor; // set scale multiplied by the scaling factor
            goTemp.transform.localScale = Vector3.one * scale; //transform the scale

            if(scale <= 0.1f)
            {
                removeList.Add(goTemp);
            }
        }//end

        foreach(GameObject goTemp in removeList)
        {
            gameObjectList.Remove(goTemp);
            Destroy(goTemp);



        }
    }
}
