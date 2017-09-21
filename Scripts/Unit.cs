using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit
{
    private int health_;
    private string team_;
    private bool busy_idle_ = false;
    private float trans_x_;
    private float trans_y_;

	public Unit(int _health, string _team, bool _busy_idle, float _trans_x, float _trans_y)
	{
        health_ = _health;
        team_ = _team;
        busy_idle_ = _busy_idle;
        trans_x_ = _trans_x;
        trans_y_ = _trans_y;
	}
    #region Getter & Setter
    public int getHealth() { return health_; }
    public string getTeam() { return team_; }
    public bool getBusy_Idle() { return busy_idle_; }
    public float getTrans_x() { return trans_x_; }
    public float getTrans_y() { return trans_y_; }

    public void setHealth(int i_setter) { health_ = i_setter; }
    public void setTeam_(string s_setter) { team_ = s_setter; }
    public void setTrans_x(float f_setter) { trans_x_ = f_setter; }
    public void setTrans_y(float f_setter) { trans_y_ = f_setter; }
    #endregion

}
            