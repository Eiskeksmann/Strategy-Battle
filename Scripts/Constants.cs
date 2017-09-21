using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    //~~~~~~~~~~~~~~~~//
    //    CONSTANT    //
    //~~~~~~~~~~~~~~~~//

    private const int zero = 0;
    private const int tile_size = 16;
   
    private const int testbench_map_size = 30;
    private const int map_offset = 1;

    private const int menu_index = 4;
    private const int menu_layer = -5;

    private const int grass_index = 8;
    private const int grass_container_index = 7;

    private const int mountain_index = 4;
    private const int mountain_container_index = 3;

    private const int harvest_index = 2;
    private const int harvest_container_index = 1;

    private const int water_index = 1;
    private const int water_container_index = 0;

    //~~~~~~~~~~~~~~~~//
    // RETURNCONSTANT //
    //~~~~~~~~~~~~~~~~//

    public static int ZERO()
    {
        return zero;
    }
    public static int TILE_SIZE()
    {
        return tile_size;
    }

    public static int MENU_INDEX()
    {
        return menu_index;
    }
    public static int MENU_LAYER()
    {
        return menu_layer;
    }

    public static int TESTBENCH_MAP_SIZE()
    {
        return testbench_map_size;
    }
    public static int MAP_OFFSET()
    {
        return map_offset;
    }

    public static int GRASS_INDEX()
    {
        return grass_index;
    }
    public static int GRASS_CONTAINER_INDEX()
    {
        return grass_container_index;
    }

    public static int MOUNTAIN_INDEX()
    {
        return mountain_index;
    }
    public static int MOUNTAIN_CONTAINER_INDEX()
    {
        return mountain_container_index;
    }

    public static int HARVEST_INDEX()
    {
        return harvest_index;
    }
    public static int HARVEST_CONTAINER_INDEX()
    {
        return harvest_container_index;
    }

    public static int WATER_INDEX()
    {
        return water_index;
    }
    public static int WATER_CONTAINER_INDEX()
    {
        return water_container_index;
    }

}