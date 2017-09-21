using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;

public class TileManager
{
    //Grass 
    private GameObject[] grass_container = new GameObject[Constants.GRASS_INDEX() + 1];

    //Mountain
    private GameObject[] mountain_container = new GameObject[Constants.MOUNTAIN_INDEX()];

    //Water
    private GameObject[] water_container = new GameObject[Constants.WATER_INDEX()];

    //Objects that can be harvested
    private GameObject[] harvest_container = new GameObject[Constants.HARVEST_INDEX()];

    //Temporary Container
    private GameObject[] add_container;

    public TileManager(GameObject[] _grass, GameObject[] _mountain, GameObject[] _water, GameObject[] _harvest)
    {
        grass_container = _grass;
        mountain_container = _mountain;
        water_container = _water;
        harvest_container = _harvest;
    }

    // Return Random Grass Tile
    public GameObject Grass_Pattern()
    {
        var selector = Constants.ZERO();

        GameObject pattern;
        selector = Random.Range(Constants.ZERO(), Constants.GRASS_INDEX());
        pattern = grass_container[selector];

        return pattern;
    }
    // Return Random Mountain Tile
    public GameObject Mountain_Pattern()
    {
        var selector = Constants.ZERO();

        GameObject pattern = mountain_container[selector];
        selector = Random.Range(Constants.ZERO(), Constants.MOUNTAIN_CONTAINER_INDEX());
        pattern = mountain_container[selector];

        return pattern;
    }

    public void addContainer(GameObject[] _temp)
    {
        add_container = _temp;
    }

    public GameObject getSpriteFromAddContainer(int selector)
    {
        return add_container[selector];
    }

    public GameObject[] getGrassContainer() { return grass_container; }
    public GameObject[] getMountainContainer() { return mountain_container; }
    public GameObject[] getHarvestContainer() { return harvest_container; }
}
