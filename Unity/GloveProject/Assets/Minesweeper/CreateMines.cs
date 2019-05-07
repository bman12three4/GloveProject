using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMines : MonoBehaviour
{

    public GameObject mine;
    public GameObject[,] mines = new GameObject[6, 4];

    public int numMines = 4;

    public bool lose = false;

    // Use this for initialization
    void Start()
    {

        /*
			Run through the array of mines and instantiate a new mine prefab at each idnex
		 */

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                mines[i, j] = Instantiate(mine, new Vector3(i * 2, j * 2), Quaternion.identity);	// Make the mines
				mines[i, j].transform.eulerAngles = new Vector3(0, 90, 0);
                mines[i, j].transform.parent = this.transform; // make this transform (mine-master) the parent of all mines, so they can access its arrays
                int[] loc = { i, j };						   
                mines[i, j].GetComponent<MineController>().loc = loc; // set the location of the mine, so it knows where it is in the array
            }

        }


		/*
			Loop through the array and randomly add the number of mines specified.
		 */
        for (int i = 0; i < numMines; i++)
        {
            int[] coords = rand();  // Get random coordinates
            bool cont = false;
            while (!cont)
            {
                if (mines[coords[0], coords[1]].GetComponent<MineController>().isMine) // if that random tile is already a mine, get another one
                {
                    cont = false;
                    coords = rand();
                }
                else
                {
                    cont = true;  // once a tile is found that is open, it continues.
                }
            }
            mines[coords[0], coords[1]].GetComponent<MineController>().isMine = true; // make that tile a mine.
        }



    }

    // Update is called once per frame
    void Update()
    {

    }

	/**
		Get a random set of coordinates
	 */
    int[] rand()
    {
        int x = Random.Range(0, 6);	
        int y = Random.Range(0, 4);

        int[] ret = { x, y };
        return ret;
    }
}
