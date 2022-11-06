using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBarricades : MonoBehaviour
{
    public GameObject Empty;
    public GameObject Barricade;

    private GameObject obj;
    private int _chanceOfAppearing;
    private float _chanceOfRotation;
    private Vector3 _spawnPos = new Vector3(0f, 0f, 66.8f);
    private float _spawnPosPlus = 66.8f;

    private void Awake()
    {
    }
    void Start()
    {
        for (int i = -2; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                _chanceOfAppearing = Random.Range(0, 100);
                if (_chanceOfAppearing <= 70)
                {
                    //_chanceOfRotation = Random.Range(0.0f, 360.0f);

                    GameObject temp = Instantiate(Empty, _spawnPos, Empty.transform.rotation) as GameObject;
                    temp.name = (i * 10).ToString();
                    GameObject barricade = Instantiate(Barricade) as GameObject;

                    barricade.transform.SetParent(temp.transform, false);
                    temp.transform.SetParent(gameObject.transform, false);
                    temp.transform.position = new Vector3(0f, 0f, (i * 10));
                    temp.transform.rotation = new Quaternion(temp.transform.rotation.x, temp.transform.rotation.y, Random.Range(0.0f, 360.0f), temp.transform.rotation.w);
                }
            }
        }
    }
}
