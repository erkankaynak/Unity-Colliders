using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public int goldCount;
    

    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;
    public GameObject text;

    private Rigidbody rb;
    private bool isGameOver;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }
    void Update()
    {
        if (isGameOver == false)
        {
            var direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var obj = collision.gameObject;

        if (obj.CompareTag("Gold"))
        {
            goldCount++;
            Destroy(obj);

            if (goldCount == 4) door1.SetActive(false);
            if (goldCount == 10) door2.SetActive(false);
            if (goldCount == 14) door3.SetActive(false);
            if (goldCount == 17) door4.SetActive(false);
        }

        if (obj.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(0); // Restart Game
        }

        if (obj.CompareTag("WinArea"))
        {
            isGameOver = true;
            text.SetActive(true);
        }
    }

}
