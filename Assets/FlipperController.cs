using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
    private float screenWidth = Screen.width;
    private HingeJoint myHingeJoint;
    private GameObject gameObj;
    private float defaultAngle = 20.0f;
    private float flickAngle = -20.0f;

    private bool leftTouched = false;
    private bool rightTouched = false;
    // Start is called before the first frame update
    void Start()
    {
        this.myHingeJoint = GetComponent<HingeJoint>();
        this.gameObj = this.gameObject;
        SetAngle(this.defaultAngle);
    }

    void CheckTouch(){
        if(Input.touchCount > 0){
            for(int i = 0; i < Input.touchCount; i++){
                Touch touch = Input.GetTouch(i);
                if(touch.phase == TouchPhase.Began){
                    if(touch.position.x > screenWidth/2){
                        rightTouched = true;
                    }
                    if(touch.position.x < screenWidth/2){
                        leftTouched = true;
                    }
                }

                if(touch.phase == TouchPhase.Ended){
                    if(touch.position.x > screenWidth/2){
                        rightTouched = false;
                    }
                    if(touch.position.x < screenWidth/2){
                        leftTouched = false;
                    }
                }
            }
                
            
            

            // if(touch.phase == TouchPhase.Began || touch1.phase == TouchPhase.Began){
            //     if(touch.position.x > screenWidth/2 || touch1.position.x > screenWidth/2 ){
            //         rightTouched = true;
            //     }
            //     if(touch.position.x < screenWidth/2 || touch1.position.x < screenWidth/2 ){
            //         leftTouched = true;
            //     }
            // }

            // if(touch.phase == TouchPhase.Ended || touch1.phase == TouchPhase.Ended){
            //     if(touch.position.x > screenWidth/2 || touch1.position.x > screenWidth/2 ){
            //         rightTouched = false;
            //     }
            //     if(touch.position.x < screenWidth/2 || touch1.position.x < screenWidth/2 ){
            //         leftTouched = false;
            //     }
            // }

            
            // if(touch.position.x > screenWidth/2){
            //     switch(touch.phase){
            //         case TouchPhase.Began:
            //             rightTouched = true;
            //             break;
            //         case TouchPhase.Ended:
            //             rightTouched = false;
            //             break;
            //         default:
            //             break;
            //     }
            // }else{
            //     switch(touch.phase){
            //         case TouchPhase.Began:
            //             leftTouched = true;
            //             break;
            //         case TouchPhase.Ended:
            //             leftTouched = false;
            //             break;
            //         default:
            //             break;
            //     }
            // }          

            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        CheckTouch();

        if((Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.A)||leftTouched) && tag=="LeftFlipperTag"){
            SetAngle(this.flickAngle);
        }
        if((Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.D)||rightTouched) && tag=="RightFlipperTag"){
            SetAngle(this.flickAngle);
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)||Input.GetKeyDown(KeyCode.S)){
            SetAngle(this.flickAngle);
        }

        if((Input.GetKeyUp(KeyCode.LeftArrow)||Input.GetKeyUp(KeyCode.A)||!leftTouched) && tag=="LeftFlipperTag"){
            SetAngle(this.defaultAngle);
        }
        if((Input.GetKeyUp(KeyCode.RightArrow)||Input.GetKeyUp(KeyCode.D)||!rightTouched) && tag=="RightFlipperTag"){
            SetAngle(this.defaultAngle);
        }
        if(Input.GetKeyUp(KeyCode.DownArrow)||Input.GetKeyUp(KeyCode.S)){
            SetAngle(this.defaultAngle);
        }
    }

    void SetAngle(float angle){
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
