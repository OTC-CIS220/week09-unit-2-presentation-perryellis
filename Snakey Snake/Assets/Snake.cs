using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Snake : MonoBehaviour {
    Vector2 dir = Vector2.right;
    bool ate = false;
    List<Transform> tail = new List<Transform>();
    public GameObject tailPrefab;

    // Use this for initialization
    void Start () {
        //Will move the snake
        InvokeRepeating("Move", 0, 0.5f);
    }
	
	// Update is called once per frame
	void Update () {
        // Will let you move with arrow keys
        if (Input.GetKey(KeyCode.RightArrow))
            dir = Vector2.right;
        else if (Input.GetKey(KeyCode.DownArrow))
            dir = -Vector2.up;   
        else if (Input.GetKey(KeyCode.LeftArrow))
            dir = -Vector2.right; 
        else if (Input.GetKey(KeyCode.UpArrow))
            dir = Vector2.up;

        //Wil let you move with A,W,S,D
        if (Input.GetKey(KeyCode.D))
            dir = Vector2.right;
        else if (Input.GetKey(KeyCode.S))
            dir = -Vector2.up;    
        else if (Input.GetKey(KeyCode.A))
            dir = -Vector2.right; 
        else if (Input.GetKey(KeyCode.W))
            dir = Vector2.up;
    }

    //Will move the snake into a direction
    void Move()
    {
        Vector2 v = transform.position;

        // Move head into new direction
        transform.Translate(dir);

        //If snake has eaten insert tail piece
        if (ate)
        {
            //will insert tail piece
            GameObject i = (GameObject)Instantiate(tailPrefab,v,Quaternion.identity);

            tail.Insert(0, i.transform);

            //will set ate back to false so it wont keep growing
            ate = false;
        }
        //will check if there is a tail
        else if (tail.Count > 0)
        {
            //will have the tail follow the head
            tail.Last().position = v;

            //will add and remove tail
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    //will check and see if the snake has eaten
    void OnTriggerEnter2D(Collider2D coll)
    {
        //Will check and see if the snake ate food
        if (coll.name.StartsWith("food_Prefab"))
        {
            //will make the snake longer
            ate = true;

            //will get rid of the food the snake has eaten
            Destroy(coll.gameObject);
        }
        //will check if snake runs into border or its self
        else
        {
            // ToDo 'You lose' screen
        }
    }
}
