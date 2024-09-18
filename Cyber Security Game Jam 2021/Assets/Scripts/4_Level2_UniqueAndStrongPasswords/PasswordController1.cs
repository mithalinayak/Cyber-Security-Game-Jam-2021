﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using UnityEngine.SceneManagement;
public class PasswordController1 : MonoBehaviour
{

    private string password;
    public GameObject inputField;
    public TMP_InputField inputFieldElement;
    private bool isStrongPwd;
    public GameObject mainDoor;
    public GameObject[] door;
    public Animator[] gateAnim;
    public GameObject pwdInputField;
    public GameObject[] shield;
    private int machineNumber;
    public GameObject endGameWin;
    public GameObject timeControl;
    // private List<string> list;
    private string path;
    private bool isSet;
    [SerializeField] private GameObject ladder;
    [SerializeField] private GameObject successfulLogin;
    [SerializeField] private GameObject tryAgain;

    public void Start() {
        isStrongPwd = false;
    }

     public void ReadStringInput(string s)
    {
        password = s;
        Debug.Log("password logged in:"+password);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            // path = Application.persistentDataPath + "/passwordLog.txt";
            // if(File.Exists(path))
            // {
            //     Debug.Log("did i get here!!!!!!!");
            //     list = File.ReadLines(path).ToList();
            //     Debug.Log("Successful turn into list");
            // }
            // else
            // {
            //     Debug.Log("there is no path");
            // }
            for (int i=0;i<PasswordController.list.Count;i++){
                Debug.Log("did my list come over"+PasswordController.list[i]);
            }
            if(PasswordController.list.Contains(password))
            {
                inputFieldElement.image.color = Color.green;
                setTextActive(1);
                isStrongPwd = true;
            }  
            else
            {
                inputFieldElement.image.color = Color.red;
                setTextActive(2);
                isStrongPwd = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Return)) 
        { 
            inputFieldElement.image.color = Color.white;
            if (isStrongPwd) // if password passes
            {
                mainDoor.SetActive(true);
                inputField.SetActive(false);
                switch (machineNumber)
                {
                    case 1:
                        door[0].SetActive(false);
                        // shieldAnim[0].SetBool(boolstr, true);
                        shield[9].SetActive(true);
                        shield[0].SetActive(false);
                        break;
                    case 2:
                        door[1].SetActive(false);
                        // shieldAnim[1].SetBool(boolstr+"1", true);
                        shield[0].SetActive(true);
                        shield[1].SetActive(false);
                        break;
                    case 3:
                        door[2].SetActive(false);
                        // shieldAnim[2].SetBool(boolstr+"2", true);
                        shield[1].SetActive(true);
                        shield[2].SetActive(false);
                        break;
                    case 4:
                        door[3].SetActive(false);
                        // shieldAnim[3].SetBool(boolstr+"3", true);
                        shield[2].SetActive(true);
                        shield[3].SetActive(false);
                        break;
                    case 5:
                        door[4].SetActive(false);
                        gateAnim[0].SetBool("playMovingUp", true);
                        // shieldAnim[4].SetBool(boolstr+"4", true);
                        shield[3].SetActive(true);
                        shield[4].SetActive(false);
                        break;
                    case 6:
                        door[5].SetActive(false);
                        // shieldAnim[5].SetBool(boolstr+"5", true);
                        shield[4].SetActive(true);
                        shield[5].SetActive(false);
                        break;
                    case 7:
                        door[6].SetActive(false);
                        // shieldAnim[6].SetBool(boolstr+"6", true);
                        shield[5].SetActive(true);
                        shield[6].SetActive(false);
                        break;
                    case 8:
                        door[7].SetActive(false);
                        // shieldAnim[7].SetBool(boolstr+"7", true);
                        shield[6].SetActive(true);
                        shield[7].SetActive(false);
                        break;
                    case 9:
                        door[8].SetActive(false);
                        // shieldAnim[8].SetBool(boolstr+"8", true);
                        shield[7].SetActive(true);
                        shield[8].SetActive(false);
                        break;
                    case 10:
                        gateAnim[1].SetBool("isPressed", true);
                        door[9].SetActive(false);
                        shield[8].SetActive(true);
                        shield[9].SetActive(false);
                        break;
                }
            }
            inputFieldElement.text ="";
            inputFieldElement.ActivateInputField();
        }
       
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "TileGroundTop (62)")
        {
            SceneManager.LoadScene("Introduction_passwordhacking");
        }
        if (other.gameObject.name == "button (11)")
        {
            timeControl.SetActive(false);
            pwdInputField.SetActive(false);
            endGameWin.SetActive(true);
            ladder.SetActive(true);
        }
        else
        {
            if (other.gameObject.name == "button (1)")
            { 
                machineNumber = 1;
                afterActionSettings();
                
            }
            else if (other.gameObject.name == "button (2)")
            {
                machineNumber = 2;
                afterActionSettings();
            }
            else if (other.gameObject.name == "button (3)")
            {
                machineNumber = 3;
                afterActionSettings();
            }
            else if (other.gameObject.name == "button (4)")
            {
                machineNumber = 4;
                afterActionSettings();
            }
            else if (other.gameObject.name == "button (5)")
            {
                machineNumber = 5;
                afterActionSettings();
            }
            else if (other.gameObject.name == "button (6)")
            {
                machineNumber = 6;
                afterActionSettings();
            }
            else if (other.gameObject.name == "button (7)")
            {
                machineNumber = 7;
                afterActionSettings();
            }
            else if (other.gameObject.name == "button (8)")
            {
                machineNumber = 8;
                afterActionSettings();
            }
            else if (other.gameObject.name == "button (9)")
            {
                machineNumber = 9;
                afterActionSettings();
            }
            else if (other.gameObject.name == "button (10)")
            {
                machineNumber = 10;
                afterActionSettings();
            }
        }
    }
    private void afterActionSettings()
    {
        pwdInputField.SetActive(true);
        inputField.SetActive(true);
        inputFieldElement.ActivateInputField();
        inputFieldElement.text ="";
        isStrongPwd = false;
    }

    private void setTextActive(int option)
    {
        switch(option){
            case 1:
                successfulLogin.SetActive(true);
                tryAgain.SetActive(false);
                break;
            case 2:
                successfulLogin.SetActive(false);
                tryAgain.SetActive(true);
                break;
        }
    }
}

