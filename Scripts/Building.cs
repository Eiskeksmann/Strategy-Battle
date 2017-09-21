using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building
{
    private int health_;
    private int[][] foundation_size_;
    private string team_;
    private int capacity_;
    private int[] requirements_;
    private bool targetable_;

	public Building(int _health, int[][] _foundation_size, string _team, 
        int _capacity, int[] _requirements, bool _targetable)
	{
        health_ = _health;
        foundation_size_ = _foundation_size;
        team_ = _team;
        capacity_ = _capacity;
        requirements_ = _requirements;
        targetable_ = _targetable;
	}
    #region Getters & Setters
    public int getHealth() { return health_; }
    public int[][] getfoundation_size() { return foundation_size_; }
    public string getTeam() { return team_; }
    public int getCapacity() { return capacity_; }
    public int[] getRequirements() { return requirements_; }
    public bool getTargetable() { return targetable_; }

    public void setHealth(int i_setter) { health_ = i_setter; }
    public void setFoundation_size(int[][] i_setter) { foundation_size_ = i_setter; }
    public void setTeam(string s_setter) { team_ = s_setter; }
    public void setCapacity(int i_setter) { capacity_ = i_setter; }
    public void setRequirements(int[] i_setter) { requirements_ = i_setter; }
    public void setTargetable(bool b_setter) { targetable_ = b_setter; }
    #endregion
}
