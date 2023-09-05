using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class ChargeScript : MonoBehaviour
{
    private float ls;
    private float q;
    
    public float max;
    public List<Vector3> accels = new List<Vector3>();

    private Vector3 prevVel;
    private Vector3 delV;
    private Vector3 Accel;
    private GameObject plyr;
    private WorldGen wg;
    private float k;
    private float qty;
    private float threshold = 0.2f;
    private float con;
    private Vector3 center;
    private Rigidbody rb;
    private float amp;
    private Vector3 disp;
    private Vector3 EMFAt;
    private float dist;
    private Vector3 DistV;
    private ulong tick;

    void Start()
    {
        plyr = GameObject.FindGameObjectWithTag("Player");
        wg = plyr.GetComponent<WorldGen>();
        tick = 0;
        amp = this.gameObject.transform.position.y;
        center = new Vector3(0f, amp, 0f);
        rb = this.gameObject.GetComponent<Rigidbody>();
        prevVel = rb.velocity;
        Accel = new Vector3(0f, 0f, 0f);
        k = wg.k;
        con = 1f * wg.numparts;
        ls = wg.ls;
        q = wg.q;
    }
    
    public Vector3 CalcEMF(Vector3 at)
    {
        EMFAt = new Vector3(0f, 0f, 0f);
        DistV = this.transform.position - at;
        dist = DistV.magnitude;
        if (dist > threshold && dist < max)
        {
            qty = dist / (Time.fixedDeltaTime * ls);
            if (qty >= 0 && qty < accels.Count)
            {
                EMFAt = (-q / (con * Mathf.Pow(ls, 2) * dist)) * accels[(accels.Count - 1) - (int)qty];
            }
            //EMFAt = ((con * q) / (Mathf.Pow(dist, 3))) * (DistV.normalized * dist);
            else
            {
                EMFAt = new Vector3(0f, 0f, 0f);
            }
            return EMFAt;
        }
        else
        {
            return new Vector3(0f, 0f, 0f);
        }
    }

    void FixedUpdate()
    {       
        disp = this.transform.position - center;
        rb.AddForce(-k * disp, ForceMode.Force);
        
        //rb.AddForce(-this.transform.position * k, ForceMode.Force);
        
        delV = rb.velocity - prevVel;
        Accel = delV / Time.fixedDeltaTime;
        prevVel = rb.velocity;
        accels.Add(Accel);
        tick++;
    }
}
