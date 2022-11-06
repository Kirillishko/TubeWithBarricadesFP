using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float ForwardSpeed;
    public float SpreadSpeed;
    public TextMeshProUGUI text;
    public GameObject RestartButton;
    public GameObject[] Tunnel = new GameObject [2];
    [HideInInspector] public int Score = 0;

    public GameObject District;
    private Vector3 _spawnDistrictPosition = new Vector3 (0, 0, 66.8f);

    private bool _isAlive = true;


    void Start()
    {
        Tunnel[0] = GameObject.Find("TunnelCenter");
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Spread(-1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Spread(1);
        }
        transform.position += transform.forward *= ForwardSpeed * Time.deltaTime;

    }

    private void Spread(int direction)
    {
        if (Tunnel[1] != null)
        {
            for (int i = 0; i < 2; i++)
            {
                Tunnel[i].transform.Rotate(new Vector3(Tunnel[i].transform.rotation.x, Tunnel[i].transform.rotation.y, SpreadSpeed * Time.deltaTime * direction));
            }
        }
        else Tunnel[0].transform.Rotate(new Vector3(Tunnel[0].transform.rotation.x, Tunnel[0].transform.rotation.y, SpreadSpeed * Time.deltaTime * direction));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            GameObject temp = Instantiate(District, _spawnDistrictPosition, District.transform.rotation) as GameObject;
            Tunnel[1] = Tunnel[0];
            Tunnel[0] = temp;
            Destroy(other.gameObject);
            _spawnDistrictPosition.z += 66.8f;

        }
        if (other.gameObject.tag == "Finish")
        {
            ForwardSpeed += 0.05f;
            Score++;
            text.text = "Ñ÷¸ò : " + Score.ToString();
            Destroy(GameObject.Find("TunnelCenter"));
            GameObject.Find("TunnelCenter(Clone)").name = "TunnelCenter";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "GameOver")
        {
            ForwardSpeed = 0f;
            SpreadSpeed = 0f;
            RestartButton.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }    
}
