using UnityEngine;
using System.Collections;

public class MenuHandler : MonoBehaviour
{
    public GameObject[] menu_container;
    

    private GameObject gManager_;
    private MapManager mManager_;
    private TileManager tManager_;
    private Transform menu_handler_;
    private CameraMovement cam_info_;
    private GameObject selectMenu_;
    private GameObject cam_;
    private GameObject col_;
    private GameObject build_;
    private GameObject unit_;
    private Transform pos_;

    private Vector3 hit_;
    private BoxCollider2D hitbox_col_;
    private BoxCollider2D hitbox_build_;
    private BoxCollider2D hitbox_unit_;

    private int state_sel_col;
    private int state_sel_build;
    private int state_sel_unit;
    private float pos_x;
    private float pos_y;
    private bool hit_col;
    private bool hit_build;
    private bool hit_unit;

    private enum menu_state
    {
        tab_col_o,
        tab_col_x,
        tab_col_t,
        tab_build_o,
        tab_build_x,
        tab_unit_o,
        tab_unit_x
    }
    // Use this for initialization
    void Start()
    {
        initMenu();
    }

    // Update is called once per frame
    private void Update()
    {
        checkStateSwitch();
        checkGateLogic();
    }

    void checkGateLogic()
    {
        //TODO : Set the state_sel values the right way.
        if(!hit_col)
        {
            state_sel_col = (int)menu_state.tab_col_o;
            state_sel_build = (int)menu_state.tab_build_x;
            state_sel_unit = (int)menu_state.tab_unit_x;
        }
        if(hit_col && !hit_build && !hit_unit)
        {
            state_sel_col = (int)menu_state.tab_col_x;
            state_sel_build = (int)menu_state.tab_build_o;
            state_sel_unit = (int)menu_state.tab_unit_o;
        }
        if(hit_col && hit_build && !hit_unit)
        {
            state_sel_col = (int)menu_state.tab_col_t;
            state_sel_build = (int)menu_state.tab_build_x;
            state_sel_unit = (int)menu_state.tab_unit_o;
        }
        if(hit_col && !hit_build && hit_unit)
        {
           state_sel_col = (int)menu_state.tab_col_t;
           state_sel_build = (int)menu_state.tab_build_o;
           state_sel_unit = (int)menu_state.tab_unit_x;
        }  
        else
        {
            state_sel_col = (int)menu_state.tab_col_t;
            state_sel_build = (int)menu_state.tab_build_o;
            state_sel_unit = (int)menu_state.tab_unit_o;
        }
    }
    void LateUpdate()
    {
            changeSelectMenu(state_sel_col);
            col_.transform.localPosition = calculateMenuPosition(state_sel_col);
            changeSelectMenu(state_sel_build);
            build_.transform.localPosition = calculateMenuPosition(state_sel_build);
            changeSelectMenu(state_sel_unit);
            unit_.transform.localPosition = calculateMenuPosition(state_sel_unit);
    }

    void initMenu()
    {
        cam_ = GameObject.Find("Main Camera");
        pos_ = cam_.GetComponent<Transform>();
        cam_info_ = cam_.GetComponent<CameraMovement>();
        menu_handler_ = new GameObject("Menu").transform;

        gManager_ = GameObject.Find("GameManager");
        mManager_ = gManager_.GetComponent<MapManager>();
        tManager_ = mManager_.get_tManager();
        tManager_.addContainer(menu_container);

        //state_sel_col = (int)menu_state.tab_col_o;
        //state_sel_build = (int)menu_state.tab_build_x;
        //state_sel_unit = (int)menu_state.tab_unit_x;

        hit_col = false;
        hit_build = false;
        hit_unit = false;

        checkGateLogic();

        changeSelectMenu(state_sel_col);
        col_ = Instantiate(selectMenu_, calculateMenuPosition(state_sel_col), Quaternion.identity) as GameObject;
        hitbox_col_ = col_.AddComponent<BoxCollider2D>();
        col_.transform.SetParent(menu_handler_);

        changeSelectMenu(state_sel_build);
        build_ = Instantiate(selectMenu_, calculateMenuPosition(state_sel_build), Quaternion.identity) as GameObject;
        hitbox_build_ = build_.AddComponent<BoxCollider2D>();
        build_.transform.SetParent(menu_handler_);

        changeSelectMenu(state_sel_unit); 
        unit_ = Instantiate(selectMenu_, calculateMenuPosition(state_sel_unit), Quaternion.identity) as GameObject;
        hitbox_unit_ = unit_.AddComponent<BoxCollider2D>();
        unit_.transform.SetParent(menu_handler_);

    }

    private Vector3 calculateMenuPosition(int index)
    {
        Vector3 vect = new Vector3();
        PixelPerfectCamera pcam = cam_.GetComponent<PixelPerfectCamera>();
        pos_x = pcam.transform.localPosition.x;
        pos_y = pcam.transform.localPosition.y;
        switch (index)
        {
            case (int)menu_state.tab_col_o:
                vect.x = pos_x - pcam.targetCameraHalfHeight + Constants.MAP_OFFSET();
                vect.y = pos_y + Constants.MAP_OFFSET();
                vect.z = Constants.MENU_INDEX();
                break;
            case (int)menu_state.tab_col_x:
                vect.x = pos_x - pcam.targetCameraHalfHeight + Constants.MAP_OFFSET();
                vect.y = pos_y + Constants.MAP_OFFSET();
                vect.z = Constants.MENU_INDEX();
                break;
            case (int)menu_state.tab_col_t:
                vect.x = pos_x - pcam.targetCameraHalfHeight + Constants.MAP_OFFSET();
                vect.y = pos_y + Constants.MAP_OFFSET();
                vect.z = Constants.MENU_INDEX();
                break;
            case (int)menu_state.tab_build_o:
                vect.x = pos_x - pcam.targetCameraHalfHeight + Constants.MAP_OFFSET();
                vect.y = pos_y;
                vect.z = Constants.MENU_INDEX();
                break;
            case (int)menu_state.tab_build_x:
                vect.x = pos_x - pcam.targetCameraHalfHeight + Constants.MAP_OFFSET();
                vect.y = pos_y;
                vect.z = Constants.MENU_INDEX();
                break;
            case (int)menu_state.tab_unit_o:
                vect.x = pos_x - pcam.targetCameraHalfHeight + Constants.MAP_OFFSET();
                vect.y = pos_y - Constants.MAP_OFFSET();
                vect.z = Constants.MENU_INDEX();
                break;
            case (int)menu_state.tab_unit_x:
                vect.x = pos_x - pcam.targetCameraHalfHeight + Constants.MAP_OFFSET();
                vect.y = pos_y - Constants.MAP_OFFSET();
                vect.z = Constants.MENU_INDEX();
                break;
        }
        return vect;
    }

    private void changeSelectMenu(int index)
    {
        selectMenu_ = tManager_.getSpriteFromAddContainer(index);
    }

    private void checkStateSwitch()
    {
        if(Input.GetMouseButtonDown(0))
        {
           
            hit_ = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //TESTCASE//
            print(hit_.x);
            if (hitbox_col_.OverlapPoint(hit_) && !hit_col)
            {
                hit_col = true;
            }

            if(hitbox_build_.OverlapPoint(hit_))
            {
                if(hit_build)
                {
                    hit_build = false;
                } 
                else
                {
                    hit_build = true;
                    hit_unit = false;
                }
            }

            if(hitbox_unit_.OverlapPoint(hit_))
            {
                if (hit_unit)
                {
                    hit_unit = false;
                }
                else
                {
                    hit_unit = true;
                    hit_build = false;
                }
            }
        }
    }
}
