using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMines : MonoBehaviour
{

    public GameObject mine;
    public GameObject[,] mines = new GameObject[8, 6];

    public int numMines = 8;

    // Use this for initialization
    void Start()
    {

        for (int i = 0; i < 8; i++)
        { // change this back to 12
            for (int j = 0; j < 6; j++)
            {
                mines[i, j] = Instantiate(mine, new Vector3(i * 2, j * 2), Quaternion.identity);
                mines[i, j].transform.parent = this.transform;
                int[] loc = { i, j};
				Debug.Log("Making mines");
                mines[i, j].GetComponent<MineController>().loc = loc;
                //mines [i, j, k].GetComponent<MineController> ().checkd = true;
            }

        }

        for (int i = 0; i < numMines; i++)
        {
            int[] coords = rand();
            bool cont = false;
            while (!cont)
            {
                if (mines[coords[0], coords[1]].GetComponent<MineController>().isMine)
                {
                    cont = false;
                    coords = rand();
                }
                else
                {
                    cont = true;
                }
            }
            mines[coords[0], coords[1]].GetComponent<MineController>().isMine = true;
            //Debug.Log("Debug");
            //Debug.Log(coords [0] + " " + coords [1] + " " + coords [2]);
        }
        //mines [0, 0, 0].GetComponent<MineController> ().getNumber ();



    }

    // Update is called once per frame
    void Update()
    {

    }

    int[] rand()
    {
        int x = Random.Range(0, 8);
        int y = Random.Range(0, 6);

        int[] ret = { x, y};
        return ret;
    }
}
