using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;//Creamos la variable privada rb que tiene referencia a la componente Rigidbody
    public float speed;
    private int countAmarillo;
    private int countAzul;
    private int countRojo;
    private int countVerde;
    public Text textAmarillo;
    public Text textRojo;
    public Text textAzul;
    public Text textVerde;
    public Text winText;
    public Text initialText;
    public Material Pickup;
    public Material Pickup1;
    public Material Pickup2;
    public Material Pickup3;
    public GameObject Amarillo;
    public GameObject Rojo;
    public GameObject Azul;
    public GameObject Verde;
    private int num;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        countAmarillo = 0;
        countAzul = 0;
        countRojo = 0;
        countVerde = 0;
        SetCountText();
        winText.text = "";
        initialText.text = "Get 5 of each color!";
        num = 0;
    }
    void Update()
    {

    }
    void FixedUpdate()
    {
        float moveHorizonal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizonal, 0.0f, moveVertical);

        rb.AddForce(movement*speed);
    }
    void OnTriggerEnter(Collider other)
    {
        initialText.text = "";
        if (other.gameObject.CompareTag("Amarillo"))
        {
            other.gameObject.SetActive(false);
            countAmarillo = countAmarillo + 1;
            SetCountText();
            SpawnPickup();
            //Material mat = gameObject.GetComponent<Material>();
            GetComponent<Renderer>().material = Pickup;
        }
        if (other.gameObject.CompareTag("Azul"))
        {
            other.gameObject.SetActive(false);
            countAzul = countAzul + 1;
            SetCountText();
            SpawnPickup();
            GetComponent<Renderer>().material = Pickup1;
        }
        if (other.gameObject.CompareTag("Rojo"))
        {
            other.gameObject.SetActive(false);
            countRojo = countRojo + 1;
            SetCountText();
            SpawnPickup();
            GetComponent<Renderer>().material = Pickup2;
        }
        if (other.gameObject.CompareTag("Verde"))
        {
            other.gameObject.SetActive(false);
            countVerde = countVerde + 1;
            SetCountText();
            SpawnPickup();
            GetComponent<Renderer>().material = Pickup3;
        }
    }
    void SetCountText()
    {
        textAmarillo.text = "Amarillo: " + countAmarillo.ToString();
        textRojo.text = "Rojo: " + countRojo.ToString();
        textAzul.text = "Azul: " + countAzul.ToString();
        textVerde.text = "Verde: " + countVerde.ToString();
        if (countAmarillo >= 5
            && countAzul>=5
            && countRojo>=5
            && countVerde>=5)
        {
            winText.text = "You Win!";
        }
    }
    private void SpawnPickup()
    {
        num = Random.Range(0, 4);
        if (num == 0)
        {
            GameObject a = Instantiate(Amarillo) as GameObject;
            a.transform.position = new Vector3(Random.Range(-9, 9), 0.5f, Random.Range(-9, 9));
        }
        if (num == 1)
        {
            GameObject a = Instantiate(Rojo) as GameObject;
            a.transform.position = new Vector3(Random.Range(-9, 9), 0.5f, Random.Range(-9, 9));
        }
        if (num == 2)
        {
            GameObject a = Instantiate(Azul) as GameObject;
            a.transform.position = new Vector3(Random.Range(-9, 9), 0.5f, Random.Range(-9, 9));
        }
        if (num == 3)
        {
            GameObject a = Instantiate(Verde) as GameObject;
            a.transform.position = new Vector3(Random.Range(-9, 9), 0.5f, Random.Range(-9, 9));
        }

    }

}
//Destroy(other.gameObject);
//if (other.gameObject.CompareTag("Player"))