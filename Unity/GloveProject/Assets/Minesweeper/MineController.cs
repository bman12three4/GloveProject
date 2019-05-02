using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : MonoBehaviour
{

    public Material blank;
    public bool isMine = false;
    public int number = 0;

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

        if (isMine)
        {
            //updateMaterial();
        }

        //number = getNumber ();
        if (number == 0)
        {
            //Destroy (this.gameObject);	
        }

        if (invisible)
        {
            this.GetComponent<Renderer>().enabled = false;
            this.GetComponent<Collider>().enabled = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "ray(Clone)")
        {

            if (!flagged)
            {
                if (isMine)
                {
                    this.GetComponent<Renderer>().material = Resources.Load<Material>("numbers/Materials/mine");
                    Application.Quit();
                }
                else
                {
                    getNumber();
                    updateMaterial();
                }
            }

        }
        else if (col.gameObject.name == "flagray(Clone)")
        {
            if (!flagged)
            {
                checkd = true;
                flagged = true;
                this.GetComponent<Renderer>().material = Resources.Load<Material>("numbers/Materials/flag");
            }
            else
            {
                checkd = false;
                flagged = false;
                this.GetComponent<Renderer>().material = blank;
            }
        }

    }

    public void getNumber()
    {
        //Debug.Log("This is the value of false [" + false + "] and this is the value of checkd [" + !checkd + "]");

        /* 

        if (!transform.parent.GetComponent<CreateMines>().mines[loc[0], loc[1], loc[2] + 1].GetComponent<MineController>().checkd)
        {
			Debug.Log("The guy behind me has not been checked");
        } else {
			Debug.Log("The guy behind me WAS checked");
		}

		*/

        if (!checkd)
        {

            checkd = true;

            for (int i = -1; i <= 1; i++)
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
                                Debug.Log("Adding mine...");
                            }
                        }
                    }
                    catch
                    {
                        //Debug.Log("error");
                    }


                }
            }

            if (number == 0)
            {
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
                                    transform.parent.GetComponent<CreateMines>().mines[loc[0] + i, loc[1] + j].GetComponent<MineController>().getNumberButNotRecursive();
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
        }
    }

    void updateMaterial()
    {

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
            else if (number > 3)
            {
                //this.GetComponent<Renderer>().material = Resources.Load<Material>("numbers/Materials/flag");
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
                    if (!(i == 0 && j == 0 ))
                    {
                        try
                        {
                            if (!transform.parent.GetComponent<CreateMines>().mines[loc[0] + i, loc[1] + j].GetComponent<MineController>().checkd)
                            {
                                if (transform.parent.GetComponent<CreateMines>().mines[loc[0] + i, loc[1] + j].GetComponent<MineController>().check())
                                {
                                    number++;
                                    Debug.Log("Adding mine...");
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
