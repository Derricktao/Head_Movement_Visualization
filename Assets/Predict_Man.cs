using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;

public class Predict_Man : MonoBehaviour
{
    public GameObject jaw;
    public GameObject r_eye_up;
    public GameObject r_eye_down;
    public GameObject l_eye_up;
    public GameObject l_eye_down;
    public GameObject mouth_r;
    public GameObject mouth_r_up;
    public GameObject mouth_r_down;
    public GameObject mouth_l;
    public GameObject mouth_l_up;
    public GameObject mouth_l_down;
    public GameObject mouth_up;
    public GameObject mouth_down;
    public GameObject eye_brow_r;
    public GameObject eye_brow_l;
    Animator anim;
    string[] lines;

    // Start is called before the first frame update
    void Start()
    {
        jaw = GameObject.Find("jaw");
        mouth_up = GameObject.Find("oris05");
        mouth_r_up = GameObject.Find("oris03.L");
        mouth_l_up = GameObject.Find("oris03.R");
        mouth_down = GameObject.Find("oris01");
        mouth_r = GameObject.Find("oris07.L");
        mouth_l = GameObject.Find("oris07.R");
        r_eye_up = GameObject.Find("orbicularis03.L");
        r_eye_down = GameObject.Find("orbicularis04.L");
        l_eye_up = GameObject.Find("orbicularis03.R");
        l_eye_down = GameObject.Find("orbicularis04.R");
        eye_brow_r = GameObject.Find("oculi01.L");
        eye_brow_l = GameObject.Find("oculi01.R");
        print(eye_brow_l.transform.position);
        /*        print(mouth_l.transform.position);
                print(mouth_up.transform.position);
                print(mouth_r.transform.position);
                print(mouth_down.transform.position);

                print(l_eye_up.transform.position);
                print(l_eye_down.transform.position);
                print(r_eye_up.transform.position);
                print(r_eye_down.transform.position);



                print(eye_brow_r.transform.position);
                print(eye_brow_l.transform.position);*/

        /*        String filename = "Assets/GroundTruth/truth132.csv";

                lines = File.ReadAllLines(filename);
                print(lines[0][1]);*/

        //var reader = new StreamReader(File.OpenRead(@"Assets/GroundTruth/truth132.csv"));
        //string filePath = @"Assets/GroundTruth/truth212.csv";
        string filePath = @"Assets/Prediction/pred212.csv";
        StreamReader sr = new StreamReader(filePath);
        var lines = new List<string[]>();
        int Row = 0;
        while (!sr.EndOfStream)
        {
            string[] Line = sr.ReadLine().Split(',');
            lines.Add(Line);
            Row++;
            Console.WriteLine(Row);
        }

        var data = lines.ToArray();
        //132
        /*        float mouth_l_x = (float)(float.Parse(data[0][0]) / 3.34);
                float mouth_l_y = -(float)(float.Parse(data[0][1]));
                float mouth_up_x = (float)(float.Parse(data[1][0]) / 3.34);
                float mouth_up_y = -(float)(float.Parse(data[1][1]));
                float mouth_r_x = (float)(float.Parse(data[2][0]) / 3.34);
                float mouth_r_y = -(float)(float.Parse(data[2][1]));
                float l_eye_up_y = -(float)(float.Parse(data[4][1]) / 1.4);
                float l_eye_down_y = -(float)(float.Parse(data[5][1]) / 1.33);
                float r_eye_up_y = -(float)(float.Parse(data[6][1]) / 1.4);
                float r_eye_down_y = -(float)(float.Parse(data[7][1]) / 1.3);
                float eye_brow_l_y = -(float)(float.Parse(data[9][1]) / 1.38);
                float eye_brow_r_y = -(float)(float.Parse(data[12][1]) / 1.38);*/
        //212
        float mouth_l_x = (float)(float.Parse(data[0][0]) / 3.34);
        float mouth_l_y = -(float)(float.Parse(data[0][1]));
        float mouth_up_x = (float)(float.Parse(data[1][0]) / 3.34);
        float mouth_up_y = -(float)(float.Parse(data[1][1]));
        float mouth_r_x = (float)(float.Parse(data[2][0]) / 3.34);
        float mouth_r_y = -(float)(float.Parse(data[2][1]));
        float l_eye_up_y = -(float)(float.Parse(data[4][1]) / 1.55);
        float l_eye_down_y = -(float)(float.Parse(data[5][1]) / 1.45);
        float r_eye_up_y = -(float)(float.Parse(data[6][1]) / 1.55);
        float r_eye_down_y = -(float)(float.Parse(data[7][1]) / 1.45);
        float eye_brow_l_y = -(float)(float.Parse(data[9][1]) / 1.38);
        float eye_brow_r_y = -(float)(float.Parse(data[12][1]) / 1.38);

        //mouth left 
        Vector3 mouth_l_new_pos = new Vector3(mouth_l_x, mouth_l_y, mouth_l.transform.position.z);
        print(mouth_l_new_pos);
        Vector3 mouth_up_new_pos = new Vector3(mouth_up_x, mouth_up_y, mouth_up.transform.position.z);
        print(mouth_up_new_pos);
        Vector3 mouth_r_new_pos = new Vector3(mouth_r_x, mouth_r_y, mouth_l.transform.position.z);
        print(mouth_r_new_pos);
        Vector3 l_eye_up_new_pos = new Vector3(l_eye_up.transform.position.x, l_eye_up_y, l_eye_up.transform.position.z);
        print(l_eye_up_new_pos);
        Vector3 l_eye_down_new_pos = new Vector3(l_eye_down.transform.position.x, l_eye_down_y, l_eye_down.transform.position.z);
        print(l_eye_down_new_pos);
        Vector3 r_eye_up_new_pos = new Vector3(r_eye_up.transform.position.x, r_eye_up_y, r_eye_up.transform.position.z);
        print(r_eye_up_new_pos);
        Vector3 r_eye_down_new_pos = new Vector3(r_eye_down.transform.position.x, r_eye_down_y, r_eye_down.transform.position.z);
        print(r_eye_down_new_pos);
        Vector3 eye_brow_l_new_pos = new Vector3(eye_brow_l.transform.position.x, eye_brow_l_y, eye_brow_l.transform.position.z);
        print(eye_brow_l_new_pos);
        Vector3 eye_brow_r_new_pos = new Vector3(eye_brow_r.transform.position.x, eye_brow_r_y, eye_brow_r.transform.position.z);
        print(eye_brow_r_new_pos);

        mouth_l.transform.position = mouth_l_new_pos;
        mouth_up.transform.position = mouth_up_new_pos;
        mouth_r.transform.position = mouth_r_new_pos;
        l_eye_up.transform.position = l_eye_up_new_pos;
        l_eye_down.transform.position = l_eye_down_new_pos;
        r_eye_up.transform.position = r_eye_up_new_pos;
        r_eye_down.transform.position = r_eye_down_new_pos;
        eye_brow_l.transform.position = eye_brow_l_new_pos;
        eye_brow_r.transform.position = eye_brow_r_new_pos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            jaw.transform.Translate(0.1f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            jaw.transform.Translate(-0.1f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            jaw.transform.Translate(0f, 0f, -0.1f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            jaw.transform.Translate(0f, 0f, 0.1f);
        }
    }
}
