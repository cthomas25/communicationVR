/*
* Based on UniOSC sender code
* Copyright © 2018 Alexandre Gomes de Siqueira
* All rights reserved
* TEI Class Sample files - Clemson University
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using OSCsharp.Data;

namespace UniOSC
{

    /// <summary>
    /// Dispatcher button that forces a OSCConnection to send a OSC Message.
    /// Two separate states: Down and Up 
    /// </summary>
    [AddComponentMenu("UniOSC/EventDispatcherButton")]
    [ExecuteInEditMode]
    public class OscSendCheckStatus : UniOSCEventDispatcher
    {
        public int Room_number;
        public string Room_letter = "";

        public Texture CheckedOnceTexture;
        public Texture CheckedTwiceTexture;
        public Texture NotCheckedTexture;

        private Material myNewMaterial;
        private string msg_CheckedOnce = ";C1";
        private string msg_CheckedTwice = ";C2";
        private string msg_NotChecked = ";C0";

        private static List<string> state = new List<string>();

        public override void Awake()
        {
            //Find the Standard Shader
            myNewMaterial = new Material(Shader.Find("Standard"));
            //Set Texture on the material
            myNewMaterial.SetTexture("_MainTex", NotCheckedTexture);
            //Apply to GameObject
            GetComponent<MeshRenderer>().material = myNewMaterial;

            for (int i = 0; i < 130; i = i + 1)
            {
                state.Add("C0");
            }

            base.Awake();
        }

        public override void OnEnable()
        {
            base.OnEnable();
            ClearData();
            AppendData("");
        }

        public override void OnDisable()
        {
            base.OnDisable();
        }

        public void SendOSC(string fmsg)
        {
            if (_OSCeArg.Packet is OscMessage)
            {
                ((OscMessage)_OSCeArg.Packet).UpdateDataAt(0, fmsg);
            }
            else if (_OSCeArg.Packet is OscBundle)
            {
                foreach (OscMessage m in ((OscBundle)_OSCeArg.Packet).Messages)
                {
                    m.UpdateDataAt(0, fmsg);
                }
            }

            _SendOSCMessage(_OSCeArg);
        }

        void OnTouchDown()
        {
            Debug.Log("Buton:OnTouchDown");
            string msg = Room_number.ToString() + ";" +Room_letter;

            if (state[Room_number] == "C0")
            {
                msg += msg_CheckedOnce;
                SendOSC(msg);
                setButtonState();
                Debug.Log(msg);
            }
            else if (state[Room_number] == "C1")
            {
                msg += msg_CheckedTwice;
                SendOSC(msg);
                setButtonState();
                Debug.Log(msg);
            } else
            {
                msg += msg_NotChecked;
                SendOSC(msg);
                setButtonState();
                Debug.Log(msg);
            }
        }

        void OnMouseDown()
        {
            Debug.Log("Buton:OnTouchDown");
            string msg = Room_number.ToString() + ";" + Room_letter;

            if (state[Room_number] == "C0")
            {
                msg += msg_CheckedOnce;
                SendOSC(msg);
                setButtonState();
                Debug.Log(msg);
            }
            else if (state[Room_number] == "C1")
            {
                msg += msg_CheckedTwice;
                SendOSC(msg);
                setButtonState();
                Debug.Log(msg);
            }
            else
            {
                msg += msg_NotChecked;
                SendOSC(msg);
                setButtonState();
                Debug.Log(msg);
            }
        }

        void OnTouchUp()
        {
            //Debug.Log("Buton:OnTouchUp");

        }

        void OnTouchStay()
        {
            // Debug.Log("Buton:OnTouchStay");

        }

        void OnTouchExit()
        {
           
        }

        void setButtonState()
        {
            Debug.Log("OscSendBlockStatus:setButtonState");
            if (state[Room_number] == "C0")
            {
                myNewMaterial.SetTexture("_MainTex", CheckedOnceTexture);
                GetComponent<MeshRenderer>().material = myNewMaterial;
                state[Room_number] = "C1";
            }
            else if (state[Room_number] == "C1")
            {
                myNewMaterial.SetTexture("_MainTex", CheckedTwiceTexture);
                GetComponent<MeshRenderer>().material = myNewMaterial;
                state[Room_number] = "C2";
            }
            else
            {
                myNewMaterial.SetTexture("_MainTex", NotCheckedTexture);
                GetComponent<MeshRenderer>().material = myNewMaterial;
                state[Room_number] = "C0";
            }
        }

        void Update()
        {
            if (Room_number == 116 && Room_letter == "B" && Globals.check_116B == true)
            {
                setButtonState();
                Globals.check_116B = false;
            }
            if (Room_number == 116 && Room_letter == "C" && Globals.check_116C == true)
            {
                setButtonState();
                Globals.check_116C = false;
            }
            if (Room_number == 116 && Room_letter == "" && Globals.check_116 == true)
            {
                setButtonState();
                Globals.check_116 = false;
            }


            if (Room_number == 114 && Room_letter == "" && Globals.check_114 == true)
            {
                setButtonState();
                Globals.check_114 = false;
            }
            if (Room_number == 112 && Room_letter == "" && Globals.check_112 == true)
            {
                setButtonState();
                Globals.check_112 = false;
            }

            if (Room_number == 113 && Room_letter == "" && Globals.check_113 == true)
            {
                setButtonState();
                Globals.check_113 = false;
            }
            if (Room_number == 113 && Room_letter == "B" && Globals.check_113B == true)
            {
                setButtonState();
                Globals.check_113B = false;
            }
            if (Room_number == 113 && Room_letter == "C" && Globals.check_113C == true)
            {
                setButtonState();
                Globals.check_113C = false;
            }
            if (Room_number == 113 && Room_letter == "D" && Globals.check_113D == true)
            {
                setButtonState();
                Globals.check_113D = false;
            }
            if (Room_number == 113 && Room_letter == "E" && Globals.check_113E == true)
            {
                setButtonState();
                Globals.check_113E = false;
            }
            if (Room_number == 113 && Room_letter == "F" && Globals.check_113F == true)
            {
                setButtonState();
                Globals.check_113F = false;
            }
            if (Room_number == 113 && Room_letter == "G" && Globals.check_113G == true)
            {
                setButtonState();
                Globals.check_113G = false;
            }


            if (Room_number == 110 && Room_letter == "" && Globals.check_110 == true)
            {
                setButtonState();
                Globals.check_110 = false;
            }
            if (Room_number == 110 && Room_letter == "A" && Globals.check_110A == true)
            {
                setButtonState();
                Globals.check_110A = false;
            }
            if (Room_number == 110 && Room_letter == "B" && Globals.check_110B == true)
            {
                setButtonState();
                Globals.check_110B = false;
            }

            if (Room_number == 111 && Room_letter == "A" && Globals.check_111A == true)
            {
                setButtonState();
                Globals.check_111A = false;
            }
            if (Room_number == 111 && Room_letter == "B" && Globals.check_111B == true)
            {
                setButtonState();
                Globals.check_111B = false;
            }


            if (Room_number == 102 && Room_letter == "" && Globals.check_102 == true)
            {
                setButtonState();
                Globals.check_102 = false;
            }
            if (Room_number == 121 && Room_letter == "" && Globals.check_121 == true)
            {
                setButtonState();
                Globals.check_121 = false;
            }


        }
    }
}