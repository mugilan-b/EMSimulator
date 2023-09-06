using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class WorldGen : MonoBehaviour
{
    //Nodes per unit length
    public GameObject node;
    public GameObject nodes;
    public float k;
    public GameObject chg;
    public float upperlim;
    public int numparts;
    public float q;
    public float ls;
    public int acon;
    public int mode;

    private float density;
    private float range;
    private float every;
    private int cnt;
    private int i;
    private Vector3 position;
    private int j;
    private string sett;
    private string[] vals;
    private int dim;   

    void Start()
    {
        print(Application.dataPath);
        vals = new string[10];
        string path = Application.dataPath + "/set.ini";
        StreamReader reader = new StreamReader(path);
        sett = reader.ReadToEnd();
        reader.Close();
        vals = sett.Split(',');

        
        density = float.Parse(vals[0]);
        range = float.Parse(vals[1]);
        dim = int.Parse(vals[2]);
        k = int.Parse(vals[3]);
        numparts = int.Parse(vals[4]);
        upperlim = float.Parse(vals[5]);
        q = float.Parse(vals[6]);
        ls = float.Parse(vals[7]);
        acon = int.Parse(vals[8]);
        mode = int.Parse(vals[9]);
        //density,range,dim,k,numparts,upperlim,q,ls,acon,mode    

        every = 1 / density;
        cnt = (int)Mathf.Floor(range * density);
        j = 0;
        if (dim == 1)
        {
            i = 0;
            while (i <= 2 * cnt)
            {
                position = new Vector3(-range + (i * every), 0f, 0f);
                (Instantiate(node, position, Quaternion.identity) as GameObject).transform.parent = nodes.transform;

                i = i + 1;
            }
        }
        else if (dim == 2)
        {
            if (range != 0f)
            {
                while (j <= 2 * cnt)
                {
                    i = 0;
                    while (i <= 2 * cnt)
                    {
                        position = new Vector3(-range + (i * every), -range + (j * every), 0f);
                        (Instantiate(node, position, Quaternion.identity) as GameObject).transform.parent = nodes.transform;

                        i = i + 1;
                    }
                    j = j + 1;
                }
            }
        }
        else
        {
            i = 0;
            while (i <= 2 * cnt)
            {
                position = new Vector3(0f, -range + (i * every), 0f);
                (Instantiate(node, position, Quaternion.identity) as GameObject).transform.parent = nodes.transform;

                i = i + 1;
            }
            i = 0;
            while (i <= 2 * cnt)
            {
                position = new Vector3(-range + (i * every), 0f, 0f);
                (Instantiate(node, position, Quaternion.identity) as GameObject).transform.parent = nodes.transform;

                i = i + 1;
            }
        }
        if (numparts % 2 == 1 && numparts > 0)
        {            
        }
        else
        {
            numparts = 1;
        }
        j = (numparts - 1) / 2;
        i = -j;
        while (i <= j)
        {
            position = new Vector3(0f, i * 0.1f, 2f);
            Instantiate(chg, position, Quaternion.identity);
            i++;
        }
    }
}
