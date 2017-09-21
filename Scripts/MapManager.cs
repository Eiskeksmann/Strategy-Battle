using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject[] water;
    public GameObject[] grass;
    public GameObject[] mountain;
    public GameObject[] harvest;

    private TileManager Tilemanager;
    private Transform Objecthandler;
    private List<Grid> GridHandler = new List<Grid>();

    private void initMapManager()
    {
        Tilemanager = new TileManager(grass, mountain, water, harvest);
        initGridHandler();
        initMap();
    }
    private void initGridHandler()
    {
        GridHandler.Clear();
        for (var iterator_x = Constants.ZERO(); iterator_x < Constants.TESTBENCH_MAP_SIZE(); iterator_x++)
        {
            for (var iterator_y = Constants.ZERO(); iterator_y < Constants.TESTBENCH_MAP_SIZE(); iterator_y++)
            {
                GridHandler.Add(new Grid(iterator_x, iterator_y, 0f));
            }
        }
    }
    private void initMap()
    {
        Objecthandler = new GameObject("Map").transform;
        for (var iterator_y = Constants.ZERO(); iterator_y < Constants.TESTBENCH_MAP_SIZE(); iterator_y++)
        {
            for (var iterator_x = Constants.ZERO(); iterator_x < Constants.TESTBENCH_MAP_SIZE(); iterator_x++)
            {
                if(iterator_x == 5 && iterator_y == 5)
                {
                    GameObject snd_instance = Instantiate(mountain[2], new Vector3(iterator_x, iterator_y, 0f), Quaternion.identity) as GameObject;
                    snd_instance.transform.SetParent(Objecthandler);
                }
                else
                {
                    GameObject recent_tile = Tilemanager.Grass_Pattern();
                    GameObject instance = Instantiate(recent_tile, new Vector3(iterator_x, iterator_y, 0f), Quaternion.identity) as GameObject;
                    instance.transform.SetParent(Objecthandler);
                }
            }
        }
    }
    public void SetupMap()
    {
        initMapManager();
    }
    public TileManager get_tManager()
    {
        return Tilemanager;
    }
}
