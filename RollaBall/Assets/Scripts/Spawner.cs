
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;

    private GameObject g;

    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLessWait;
    public int startWait;
    public bool stop;

    int randEnemy;

    void Start()
    {

        add();
        //   g = GameObject.FindGameObjectsWithTag ("pick");
        //  StartCoroutine(waitSpawner());


    }
    private void Update()
    {

        //spawnWait = Random.Range(spawnLessWait, spawnMostWait);

    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!stop)
        {
            for (int i = 0; i < 4; i++)
            {
                GameObject gameobject;
                

                randEnemy = Random.Range(0, 4);
                float x = Random.Range(-spawnValues.x, spawnValues.x);
                float z = Random.Range(-spawnValues.z, spawnValues.z);
                Vector3 spawnPosition = new Vector3(x, 1, z);
                Vector3 spawnPosition1 = new Vector3(x, 4, z);

                int r = Random.Range(0, 2);
                int size = Random.Range(9, 15);
                string nn = "";
                if (r == 0)
                {
                    nn = "" + randpalindrom(size);

                }
                else
                {
                    nn = "" + randpalindrom(size);
                    //   nn = "" + RandomString(size);
                }
                gameobject = Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(10, 0, 0), gameObject.transform.rotation);


                gameobject.GetComponent<Rotator>().x = nn;

                // new WaitForSeconds(spawnWait);




                GameObject text = new GameObject();
                TextMesh t = text.AddComponent<TextMesh>();

                t.text = nn;
                t.fontSize = 10;
                //   GameObject ob;
                Instantiate(t, spawnPosition1 + transform.TransformPoint(10, 0, 0), gameObject.transform.rotation);



                Destroy(text);

                yield return new WaitForSeconds(spawnWait);
                if (i == 4)
                    break;
            }
            stop = true;
        }

    }
    public void add()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject gameobject;
            

            randEnemy = Random.Range(0, 4);
            float x = Random.Range(-20, 20);
            float z = Random.Range(-20, 20);
            Vector3 spawnPosition = new Vector3(x, 1, z);
            Vector3 spawnPosition1 = new Vector3(x, 4, z);

            int r = Random.Range(0, 2);
            int size = Random.Range(9, 15);
            string nn = "";
            if (r == 0)
            {
                //   nn = "" + randpalindrom(size);
                nn = "" + RandomString(size);
            }
            else
            {
                nn = "" + randpalindrom(size);
                // nn = "" + RandomString(size);
            }
            gameobject = Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(10, 0, 0), gameObject.transform.rotation);
            // GameObject g=   Instantiate(enemies1[randEnemy], spawnPosition1 + transform.TransformPoint(10, 0, 0), gameObject.transform.rotation);

            gameobject.GetComponent<Rotator>().x = nn;
            // int s = gameobject.transform.GetChildCount();
            g = gameobject;

            g.GetComponentInChildren<TextMesh>().text = nn;

            //  Debug.Log(s);
            //    // Text t = gameobject.GetComponentInChildren<Text>();
            //gameobject = Instantiate(enemies[randEnemy]);

            //t.text = nn;
            // new WaitForSeconds(spawnWait);




            //GameObject text = new GameObject();
            //  Text t = enemies[randEnemy].GetComponentInChildren<Text>();
            //  t.text = nn;
            //     t.text = nn;
            //   t.fontSize = 10;
            //   GameObject ob;
            //Instantiate(t, spawnPosition1 + transform.TransformPoint(10, 0, 0), gameObject.transform.rotation);
            // Destroy(text);

        }

    }
    private string RandomString(int size)
    {

        string _chars = "xA9";
        char[] buffer = new char[size];

        for (int i = 0; i < size; i++)
        {
            buffer[i] = _chars[Random.Range(0, 3)];
        }
        return new string(buffer);
    }
    public void remove(GameObject obj, string name)
    {


        // string name = obj.name;

        //   bool c = check(name);
        //   if (c)
        //  {
        obj.SetActive(false);
        Destroy(obj);

        //}

        /*   double x = obj.transform.position.x;
            for(int i = 0; i < 4; i++)
            {
             randEnemy = Random.Range(0, 4);
             GameObject ob = enemies[randEnemy];
                if (ob==obj)
                {
                    obj.SetActive(false);
                      Destroy(obj);
                }

            }*/
    }
    public string randpalindrom(int size)
    {

        char[] str = new char[size];
        str[0] = 'x';
        str[size - 1] = 'x';
        int end = size - 2;
        int i = 1;
        for (i = 1; i < size; i++)
        {
            int x = Random.Range(0, 2);
            if (x == 0)
            {
                str[i] = 'A';
                str[end] = 'A';
            }
            else
            {
                str[i] = '9';
                str[end] = '9';

            }
            end--;
            if (end <= i)
            {
                break;
            }
        }

        return new string(str);
    }
    public bool check(string a)
    {
        //string a = randpalindrom(size);
        string b = "";

        int n = a.Length;
        for (int i = n - 1; i >= 0; i--)
        {
            b = b + a[i];
        }
        if (a.Equals(b))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}