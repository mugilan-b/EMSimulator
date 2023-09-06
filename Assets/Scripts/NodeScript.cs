using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
    private GameObject plyr;
    private WorldGen wg;
    private float upperlim;
    private GameObject[] charges;
    private Vector3 EMField;
    private int i;
    private Transform thisTr;
    private GameObject zero;
    private MeshRenderer zeroM;
    private GameObject arrow;
    private MeshRenderer arrowM;
    private ChargeScript[] cs;
    private float x;
    private float y;
    private int acon;

    void Start()
    {
        plyr = GameObject.FindGameObjectWithTag("Player");
        wg = plyr.GetComponent<WorldGen>();
        acon = wg.acon;
        upperlim = wg.upperlim;
        x = 0f;
        y = 0f;
        EMField = new Vector3 (0, 0, 0);

        thisTr = this.gameObject.GetComponent<Transform>();

        zero = thisTr.Find("Zero").gameObject;
        zeroM = zero.GetComponent<MeshRenderer>();
        arrow = thisTr.Find("Arrow").gameObject;
        arrowM = arrow.GetComponentInChildren<MeshRenderer>();

        i = 0;
        charges = GameObject.FindGameObjectsWithTag("Charge");        
        cs = new ChargeScript[charges.Length];

        while(i < charges.Length)
        {            
            cs[i] = charges[i].GetComponent<ChargeScript>();            
            i++;
        }       
    }

    void FixedUpdate()
    {
        EMField = new Vector3(0, 0, 0);
        i = 0;
        while(i < charges.Length)
        {
            EMField = EMField + cs[i].CalcEMF(thisTr.position);
            i++;
        }

        if(EMField.magnitude == 0)
        {
            zeroM.enabled = false;
            zeroM.material.SetFloat("_Metallic", 1f);
            zeroM.material.SetFloat("_Glossiness", 1f);
            arrowM.enabled = false;
        }
        else
        {
            zeroM.enabled = false;
            arrowM.enabled = true;

            y = EMField.magnitude;
            if (y < upperlim)
            {

            }
            else
            {
                y = upperlim;
            }
            if(acon == 0)
            {
                arrow.transform.localScale = new Vector3(15f, 15f, 15f * y);
            }                        
            x = Mathf.Atan(EMField.magnitude) / (Mathf.PI / 2);
            arrowM.material.SetFloat("_Metallic", (1 - x));
            arrowM.material.SetFloat("_Glossiness", (1 - x));
            arrow.transform.SetPositionAndRotation(arrow.transform.position, Quaternion.LookRotation(-EMField));
        }        
    }
}
