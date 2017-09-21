using UnityEngine;
using System.Collections;

public class Grid
{
    private float x_;
    private float y_;
    private float z_;
    private bool found_;
    private bool walk_;
    private bool forest_;
    private bool mountain_;
    private bool boarder_;
    private bool sel_;

    public Grid(float _x, float _y, float _z, bool _found, bool _walk, bool _forest,
                    bool _mountain, bool _boarder, bool _sel)
    {
        x_ = _x;
        y_ = _y;
        z_ = _z;
        found_ = _found;
        walk_ = _walk;
        forest_ = _forest;
        mountain_ = _mountain;
        boarder_ = _boarder;
        sel_ = _sel;
    }

    public Grid(float _x, float _y, float _z)
    {
        x_ = _x;
        y_ = _y;
        z_ = _z;
        found_ = false;
        walk_ = true;
        forest_ = false;
        mountain_ = false;
        boarder_ = false;
    }

    //Getter --> for all Grid characteristics
    public float getX() { return x_; }
    public float getY() { return y_; }
    public float getZ() { return z_; }
    public bool getFound() { return found_; }
    public bool getWalk() { return walk_; }
    public bool getForest() { return forest_; }
    public bool getMountain() { return mountain_; }
    public bool getBoarder() { return boarder_; }
    public bool getSelector() { return sel_; }

    //Setter --> only for settable Grid characteristics
    public void setFound(bool _set) { found_ = _set; }
    public void setWalk(bool _set) { walk_ = _set; }
    public void setForest(bool _set) { forest_ = _set; }
    public void setBoarder(bool _set) { boarder_ = _set; }
    public void setSelector(bool _set) { sel_ = _set; }

}
