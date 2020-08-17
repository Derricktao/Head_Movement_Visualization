using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Threading;

public class test_rotation : MonoBehaviour
{
    public GameObject neck;
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
        neck = GameObject.Find("Test");
        //print(chest.transform.position);
        String filePath = @"Assets/Rotation/q_df_new.csv";
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
        //print((data[1][3]));
        //if the first row is name of data, then use data[1][.] otherwise use data[0][.]
        x_rotation_offset = float.Parse(data[1][3]);
        y_rotation_offset = float.Parse(data[1][1]);
        z_rotation_offset = float.Parse(data[1][2]);
        //if want to use the chest data, uncomment below
        /*cx_rotation_offset = float.Parse(data[0][6]);
        cy_rotation_offset = float.Parse(data[0][4]);
        cz_rotation_offset = float.Parse(data[0][5]);*/

        //quaterion
        /*        x_rotation_offset = float.Parse(data[1][2]);
                y_rotation_offset = float.Parse(data[1][3]);
                z_rotation_offset = float.Parse(data[1][4]);
                w_rotation_offset = float.Parse(data[1][1]);

                offset.Set(x_rotation_offset, y_rotation_offset, z_rotation_offset, w_rotation_offset);
                Voffset = offset.eulerAngles;*/
        //chest.transform.rotation = offset;
        //pre = offset;
        /*        print(offset.eulerAngles);*/
        //chest.transform.rotation = offset;
        //neck.transform.localRotation = Quaternion.Euler(offset.eulerAngles);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
