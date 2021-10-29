using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] List<GameObject> spherePrefabList;
    [SerializeField] Transform sphereSpawner;
    [SerializeField] Text attemptsText;

    // ENCAPSULATION
    private int _attemptsCount = 0;
    public int AttemptsCount
    {
        get { return _attemptsCount; }
        private set
        {
            Debug.Log(value);
            if (value < 0)
            {
                return;
            }

            if (value != _attemptsCount+1 && value != 0)
            {
                return;
            }

            _attemptsCount = value;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        SpawnSphere();
    }

    // ABSTRACTION
    public void SpawnSphere()
    {
        AttemptsCount++;
        attemptsText.text = "Attempts: " + AttemptsCount;
        GameObject spherePrefab = spherePrefabList[Random.Range(0, spherePrefabList.Count)];
        GameObject sphere = Instantiate(spherePrefab, sphereSpawner.position, spherePrefab.transform.rotation);
    }
}
