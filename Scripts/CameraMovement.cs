using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraMovement : MonoBehaviour {
 
    private float camera_speed_ = Constants.TILE_SIZE() * 1f;

    private float cam_heigth_ = 0;
    private float cam_width_ = 0;
    
    private bool block_x_r_ = false;
    private bool block_x_l_ = false;
    private bool block_y_u_ = false;
    private bool block_y_d_ = false;

    private Transform Pos;
    private GameObject cam;
    private PixelPerfectCamera Ppc;
    private Ray box;
    private RaycastHit hit;

	// Use this for initialization
	void Start () {
        cam = GameObject.Find("Main Camera");
        Pos = cam.transform;
	}

	// Update is called once per frame
	void Update () {

        CheckOnMenuClick();
        CheckOnCameraSize();
        UpdateCameraMovement();
 
	}

    private void UpdateCameraMovement()
    {
        if(Input.GetKey(KeyCode.DownArrow) && !block_y_d_) 
        transform.Translate(Vector3.down * camera_speed_ * Time.deltaTime);

        if(Input.GetKey(KeyCode.UpArrow) && !block_y_u_) 
        transform.Translate(Vector3.up * camera_speed_ * Time.deltaTime);

        if(Input.GetKey(KeyCode.LeftArrow) && !block_x_l_) 
        transform.Translate(Vector3.left * camera_speed_ * Time.deltaTime);

        if(Input.GetKey(KeyCode.RightArrow) && !block_x_r_) 
        transform.Translate(Vector3.right * camera_speed_ * Time.deltaTime);
    }

    private void CheckOnCameraSize()
    {
        Ppc = cam.GetComponent<PixelPerfectCamera>();
        Pos = cam.GetComponent<Transform>();
        cam_width_ = Ppc.targetCameraHalfWidth;
        cam_heigth_ = Ppc.targetCameraHalfHeight;
        
        if (Pos.localPosition.x + cam_width_ >= Constants.TESTBENCH_MAP_SIZE()) 
        {
           //block_x_r_ = true;
        }
        else
        {
            block_x_r_ = false;
        }
        if(Pos.localPosition.x - cam_width_ < Constants.ZERO()) 
        {
           //block_x_l_ = true;
        }
        else
        {
            block_x_l_ = false;
        }
        if(Pos.localPosition.y + cam_heigth_ >= Constants.TESTBENCH_MAP_SIZE())
        {
           //block_y_u_ = true;
        }
        else
        {
            block_y_u_ = false;
        }
        if(Pos.localPosition.y - cam_heigth_ + Constants.MAP_OFFSET() < Constants.ZERO())
        {
           //block_y_d_ = true;
        }
        else
        {
            block_y_d_ = false;
        }
    }

    public string CheckOnMenuClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            box = Camera.main.ScreenPointToRay(Input.mousePosition);

            if( Physics.Raycast(box, out hit, 100))
            {
                Debug.Log(hit.transform.gameObject.name);
                return hit.transform.gameObject.name;
            }
            return "";
        }
        return "";
    }
}
