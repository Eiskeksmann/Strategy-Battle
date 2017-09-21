using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager
{
    private const int OFFSET = 4;
    private const int RANGE = 2 * OFFSET + 1;

    private string team_;
    private int[,] boarder_;
    private Unit[] population_;

	public TeamManager(string _teamname, int _startgrid_x, int _startgrid_y, int _unit_limit, int _map_size)
	{
        team_ = _teamname;
        initBoarder(_map_size, _startgrid_x, _startgrid_y);
        initUnits(_unit_limit);
	}

    private void initUnits(int _unit_limit)
    {
        population_ = new Unit[_unit_limit];
    }
    private void initBoarder(int _map_size, int _start_x, int _start_y)
    {
        boarder_ = new int[_map_size, _map_size];
        for(int i = 0; i < _map_size; i++)
        {
            for(int j = 0; j < _map_size; j++)
            {
                boarder_[i, j] = 0x00;
            }

        }
        boarder_[_start_x, _start_y] = 0x10;
        extendBoarder(_start_x, _start_y);
    }

    public void extendBoarder(int _increasefrom_x, int _increasefrom_y)
    {
        for(int iterator = _increasefrom_x - OFFSET; 
                    iterator <= _increasefrom_x + OFFSET;
                        iterator++)
        {
            if(iterator == _increasefrom_x - OFFSET)
            {
                for(int column = _increasefrom_y + OFFSET;
                            column >= _increasefrom_y-OFFSET;
                                column--)
                {
                    boarder_[iterator, column] = 0x11;
                    boarder_[iterator + (RANGE - 1), column] = 0x11;
                }
            }
            else
            {
                boarder_[iterator, _increasefrom_y + OFFSET] = 0x11;
                boarder_[iterator, _increasefrom_y - OFFSET] = 0x11;
            }
        }

    }


}
