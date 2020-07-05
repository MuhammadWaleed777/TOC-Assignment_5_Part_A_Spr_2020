using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public AudioSource audio;
    private float speed = 10;
    private Rigidbody rigidBody;
    public Text countText;
    public int count;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        count = 0;
        audio = GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 mov = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidBody.AddForce(mov * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        string n = other.GetComponent<Rotator>().x;
        Spawner1 s = new Spawner1();
        if (s.check(n))
         {
             count = count + 1;
             setCount(s.getPlain());
             other.gameObject.SetActive(false);
             Destroy(other.gameObject);
         }
         else
         {
             audio.Play();
         }
    }

    void setCount(int p)
    {
        if (p == count)
        {
            countText.text = "ALL"+ p +" / " + p +"Palindromes Captured" + count.ToString();
        }
        else
        {
            countText.text = "Collected : " + count.ToString() + " / " + p; 
        }
    }
}
