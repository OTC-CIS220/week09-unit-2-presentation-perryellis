using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Developer:  Perry Ellis
/// Program:    Snakey Snake
/// Date:       3/17/2018
/// Purpose:    Be the snake Feed the snake
/// </summary>
public class Food : MonoBehaviour {

    public GameObject foodPrefab;
    public Transform topBorder;
    public Transform bottemBorder;
    public Transform leftBorder;
    public Transform rightBorder;

    // Use this for initialization
    void Start () {
        //Will spawn the food
        InvokeRepeating("FoodSpawn", 3, 4);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //Will spawn pieces of food
    void FoodSpawn()
    {
        //will pistion the food in the borders
        int x = (int)Random.Range(leftBorder.position.x,rightBorder.position.x);
        int y = (int)Random.Range(bottemBorder.position.y,topBorder.position.y);
        //Will instaniate the food
        Instantiate(foodPrefab,new Vector2(x, y),Quaternion.identity);

    }
}
