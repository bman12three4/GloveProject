using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : MonoBehaviour
{

    public Material blank;
    public bool isMine = false;
    public int number = 0;

    public bool showNumber = false;

    public bool invisible = false;
    public bool checkd = false;

    public bool flagged = false;

    public int[] loc;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // If invisible, disable collider and renderer so you can't see or interact, but other mines can.
        if (invisible)
        {
            this.GetComponent<Renderer>().enabled = false;
            this.GetComponent<Collider>().enabled = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (!transform.parent.GetComponent<CreateMines>().lose)             // If the player hasn't lost
        {
            if (col.gameObject.GetComponent<PlayerController>().clear || col.gameObject.GetComponent<ManualControl>().clear)      // And the player is in clearing mode
            {

                if (!flagged)                                               // And it's not flagged
                {
                    if (isMine)                                             // if it's a mine, the player loses
                    {
                        this.GetComponent<Renderer>().material = Resources.Load<Material>("numbers/Materials/mine");
                        transform.parent.GetComponent<CreateMines>().lose = true;
                    }
                    else
                    {                                                       // If not, it gets the number and shows it
                        getNumber();
                        updateMaterial();
                    }
                }

            }
            else if (col.gameObject.GetComponent<PlayerController>().flag || col.gameObject.GetComponent<ManualControl>().flag)  // If the player is in clearing mode
            {
                if (!flagged && !showNumber)                                // and the number isn't visible (can't flag a number) or flagged
                {
                    checkd = false;                                        // then flag it
                    flagged = true;
                    this.GetComponent<Renderer>().material = Resources.Load<Material>("numbers/Materials/flag");
                }
                else if (flagged && !showNumber)                            // If it is flagged (and also not a number, just making sure)
                {
                    checkd = false;                                         // then unflag it.
                    flagged = false;
                    this.GetComponent<Renderer>().material = blank;
                }
            }

        }
    }

    public void getNumber()
    {
        if (!checkd)                                                        // If it has already been checked, don't check again (stop infinite loops)
        {

            checkd = true;                                                  // Set it to checked (see above)

            for (int i = -1; i <= 1; i++)                                   // Check all of the squares around it
            {
                for (int j = -1; j <= 1; j++)
                {
                    try
                    {
                        if (!transform.parent.GetComponent<CreateMines>().mines[loc[0] + i, loc[1] + j].GetComponent<MineController>().checkd)
                        {
                            if (transform.parent.GetComponent<CreateMines>().mines[loc[0] + i, loc[1] + j].GetComponent<MineController>().check())
                            {
                                number++;
                                //Debug.Log("Adding mine...");
                            }
                        }
                    }
                    catch
                    {
                        //Debug.Log("error");
                    }


                }
            }
            Debug.Log("Out of first for loop");
            if (number == 0)
            {
                Debug.Log("Number was 0");
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (!(i == 0 && j == 0))
                        {
                            try
                            {
                                if (!transform.parent.GetComponent<CreateMines>().mines[loc[0] + i, loc[1] + j].GetComponent<MineController>().checkd)
                                {
                                    transform.parent.GetComponent<CreateMines>().mines[loc[0] + i, loc[1] + j].GetComponent<MineController>().getNumber();
                                }
                            }
                            catch
                            {
                                //Debug.Log("error");
                            }
                        }
                    }
                }

            }
            updateMaterial();
        }
    }

    void updateMaterial()
    {
        showNumber = true;

        if (isMine)
        {
            this.GetComponent<Renderer>().material = Resources.Load<Material>("numbers/Materials/mine");
        }
        else
        {
            if (number == 0)
            {
                Debug.Log(" destroy me");
                invisible = true;
            }
            else if (number == 1)
            {
                this.GetComponent<Renderer>().material = Resources.Load<Material>("numbers/Materials/1");
            }
            else if (number == 2)
            {
                this.GetComponent<Renderer>().material = Resources.Load<Material>("numbers/Materials/2");
            }
            else if (number == 3)
            {
                this.GetComponent<Renderer>().material = Resources.Load<Material>("numbers/Materials/3");
            }
            else if (number == 4)
            {
                this.GetComponent<Renderer>().material = Resources.Load<Material>("numbers/Materials/4");
            }
        }
    }


    public bool check()
    {
        return isMine;
    }

    public void getNumberButNotRecursive()
    {
        checkd = true;
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (!(i == 0 && j == 0))
                {
                    try
                    {
                        if (!transform.parent.GetComponent<CreateMines>().mines[loc[0] + i, loc[1] + j].GetComponent<MineController>().checkd)
                        {
                            if (transform.parent.GetComponent<CreateMines>().mines[loc[0] + i, loc[1] + j].GetComponent<MineController>().check())
                            {
                                number++;
                                //Debug.Log("Adding mine...");
                            }
                        }
                    }
                    catch
                    {
                        //Debug.Log("error");
                    }
                }
            }

        }
        updateMaterial();
    }

}
