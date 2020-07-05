
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Spawner1 : MonoBehaviour
{
    public GameObject[] enemies;

    private GameObject g;

    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLessWait;
    public int startWait;
    public bool stop;
    public static int palin = 0;
    int randEnemy;

    void Start()
    {
        add();
    }
   
    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!stop)
        {
            
                GameObject gameobject;
               

                randEnemy = Random.Range(0, 4);
                float x = Random.Range(-spawnValues.x, spawnValues.x);
                float z = Random.Range(-spawnValues.z, spawnValues.z);
                Vector3 spawnPosition = new Vector3(x, 1, z);
                Vector3 spawnPosition1 = new Vector3(x, 4, z);

                int r = Random.Range(0, 2);
                int size = Random.Range(9, 15);
                string randomm = "";
                if (r == 0)
                {
                    randomm = "" + RandomString(size);

            }
                else
                {
                palin = palin+ 1;
                    randomm = "" + randpalindrom(size);
                }
                gameobject = Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(10, 0, 0), gameObject.transform.rotation);
                gameobject.GetComponent<Rotator>().x = randomm;
                GameObject text = new GameObject();
                TextMesh t = text.AddComponent<TextMesh>();
                t.text = randomm;
                t.fontSize = 4;
                //   GameObject ob;
                Instantiate(t, spawnPosition1 + transform.TransformPoint(10, 0, 0), gameObject.transform.rotation);
                Destroy(text);
                yield return new WaitForSeconds(spawnWait);
           
        }

    }
    public void add()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject gameobject;
            

            randEnemy = Random.Range(0, 4);
            float x = Random.Range(-9, 9);
            float z = Random.Range(-9, 9);
            Vector3 spawnPosition = new Vector3(x, 0, z);
        
            int r = Random.Range(0, 2);
            int size = Random.Range(9, 15);
            string randomm = "";
            if (r == 0)
            {
               
                 randomm = "" + RandomString(size);
            }
            else
            {
                palin = palin + 1;
                randomm = "" + randpalindrom(size);
            }
            gameobject = Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            gameobject.GetComponent<Rotator>().x = randomm;
            
            g = gameobject;

            g.GetComponentInChildren<TextMesh>().text = randomm;

        }

    }
    private string RandomString(int size)
    {

        string _chars = "xM2";
        char[] buffer = new char[size];

        for (int i = 0; i < size; i++)
        {
            buffer[i] = _chars[Random.Range(0, 3)];
        }
        return new string(buffer);
    }
    public void remove(GameObject obj, string name)
    {
        obj.SetActive(false);
        Destroy(obj);
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
                str[i] = 'M';
                str[end] = 'M';
            }
            else
            {
                str[i] = '2';
                str[end] = '2';

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
    public int getPlain()
    {
        
        return palin;
    }
}