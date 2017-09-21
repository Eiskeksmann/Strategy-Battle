using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public MapManager map;

    // Use this for initialization
    void Awake()
    {
        map = GetComponent<MapManager>();
        initGameManager();
    }

    private void initGameManager()
    {
        map.SetupMap();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
