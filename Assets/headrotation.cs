using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Threading;

public class headrotation : MonoBehaviour
{
    public GameObject neck;
    public GameObject chest;
    string[] lines;
    public int line_number = 1;
    string[][] data;
    public float x_rotation_offset = 0;
    public float y_rotation_offset = 0;
    public float z_rotation_offset = 0;
    public float w_rotation_offset = 0;
    public float cx_rotation_offset = 0;
    public float cy_rotation_offset = 0;
    public float cz_rotation_offset = 0;
    public Vector3 Voffset;
    public Quaternion offset = new Quaternion();
    public Quaternion pre = new Quaternion();
    int Row = 0;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 15;
        neck = GameObject.Find("neck02");
        chest = GameObject.Find("Head_Man");
        String filePath = @"Assets/Rotation/final_ryp_0817.csv";
        StreamReader sr = new StreamReader(filePath);
        var lines = new List<string[]>();
        while (!sr.EndOfStream)
        {
            string[] Line = sr.ReadLine().Split(',');
            lines.Add(Line);
            Row++;
            Console.WriteLine(Row);
        }
        data = lines.ToArray();
        read_eular();
        //read_quaternion();
    }


    // Update is called once per frame
    void Update()
    {
        if (line_number <= Row)
        {
            update_eular(line_number);
            //var new_rotation = new Quaternion();
            //new_rotation = rotation * Quaternion.Inverse(offset);
            //print("head rotation is: "+rotation);
            //if want to use the chest data, uncomment below
            /*            if (x_r > 90)s
                        {
                            x_r = x_r - 90;
                        }*/
            // print(line_number + " yaw is: " + y_r);
            /*            if (y_r > 45 && y_r <180)
                        {
                            y_r = y_r - 90;
                        }*/
            /*if (y_r > 360)
            {
                y_r = y_r - 360;
            }*/


            //print(data[line_number][3]);
            /*        var x_rotation = float.Parse(data[line_number][3]) - x_rotation_offset;
                    var y_rotation = float.Parse(data[line_number][1]) - y_rotation_offset;
                    var z_rotation = float.Parse(data[line_number][2]) - z_rotation_offset;*/ 
            line_number++;
        }
        
    }

    void read_eular()
    {
        x_rotation_offset = float.Parse(data[1][3]);
        y_rotation_offset = float.Parse(data[1][1]);
        z_rotation_offset = float.Parse(data[1][2]);
    }

    void read_quaternion()
    {
        x_rotation_offset = float.Parse(data[1][2]);
        y_rotation_offset = float.Parse(data[1][3]);
        z_rotation_offset = float.Parse(data[1][4]);
        w_rotation_offset = float.Parse(data[1][1]);
        offset.Set(x_rotation_offset, y_rotation_offset, z_rotation_offset, w_rotation_offset);
        //chest.transform.rotation = offset;
        pre = offset;
    }

    void update_eular(int line_number)
    {
        var x_r = float.Parse(data[line_number][3]) - x_rotation_offset;
        var y_r = float.Parse(data[line_number][1]) - y_rotation_offset;
        var z_r = float.Parse(data[line_number][2]) - z_rotation_offset;
        neck.transform.localRotation = Quaternion.Euler(x_r, y_r, z_r);
    }

    void update_quaternion(int line_number)
    {
        var x_r = float.Parse(data[line_number][2]);
        var y_r = float.Parse(data[line_number][3]);
        var z_r = float.Parse(data[line_number][4]);
        var w_r = float.Parse(data[line_number][1]);
        var rotation = new Quaternion();
        rotation.Set(x_r, y_r, z_r, w_r);
        neck.transform.localRotation = rotation;
        pre = rotation;
    }
}
