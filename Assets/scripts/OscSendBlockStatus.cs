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
    public class OscSendBlockStatus : UniOSCEventDispatcher
    {
        public int Room_number;
        public string Room_letter = "";

        public Texture blockedTexture;
        public Texture notBlockedTexture;

        private Material myNewMaterial;
        private string msg_blocked = ";B";
        private string msg_notBlocked = ";NB";

        private static List<string> state = new List<string>();

        public override void Awake()
        {
            //Find the Standard Shader
            myNewMaterial = new Material(Shader.Find("Standard"));
            //Set Texture on the material
            myNewMaterial.SetTexture("_MainTex", notBlockedTexture);
            //Apply to GameObject
            GetComponent<MeshRenderer>().material = myNewMaterial;

            for (int i = 0; i < 130; i = i + 1)
            {
                state.Add("NB");
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

            if (state[Room_number] == "NB")
            {
                msg += msg_blocked;
                SendOSC(msg);
                setButtonState();
                Debug.Log(msg);
            }
            else 
            {
                msg += msg_notBlocked;
                SendOSC(msg);
                setButtonState();
                Debug.Log(msg);
            }
        }

        void OnMouseDown()
        {
            Debug.Log("Buton:OnTouchDown");
            string msg = Room_number.ToString() + ";" + Room_letter;

            if (state[Room_number] == "NB")
            {
                msg += msg_blocked;
                SendOSC(msg);
                setButtonState();
                Debug.Log(msg);
            }
            else
            {
                msg += msg_notBlocked;
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
            if (state[Room_number] == "NB")
            {
                myNewMaterial.SetTexture("_MainTex", blockedTexture);
                GetComponent<MeshRenderer>().material = myNewMaterial;
                state[Room_number] = "B";
            }
            else
            {
                myNewMaterial.SetTexture("_MainTex", notBlockedTexture);
                GetComponent<MeshRenderer>().material = myNewMaterial;
                state[Room_number] = "NB";
            }
        }

        void Update()
        {
            if (Room_number == 116 && Room_letter == "B" && Globals.block_116B == true)
            {
                setButtonState();
                Globals.block_116B = false;
            }
            if (Room_number == 116 && Room_letter == "C" && Globals.block_116C == true)
            {
                setButtonState();
                Globals.block_116C = false;
            }
            if (Room_number == 116 && Room_letter == "" && Globals.block_116 == true)
            {
                setButtonState();
                Globals.block_116 = false;
            }


            if (Room_number == 114 && Room_letter == "" && Globals.block_114 == true)
            {
                setButtonState();
                Globals.block_114 = false;
            }
            if (Room_number == 112 && Room_letter == "" && Globals.block_112 == true)
            {
                setButtonState();
                Globals.block_112 = false;
            }

            if (Room_number == 113 && Room_letter == "" && Globals.block_113 == true)
            {
                setButtonState();
                Globals.block_113 = false;
            }
            if (Room_number == 113 && Room_letter == "B" && Globals.block_113B == true)
            {
                setButtonState();
                Globals.block_113B = false;
            }
            if (Room_number == 113 && Room_letter == "C" && Globals.block_113C == true)
            {
                setButtonState();
                Globals.block_113C = false;
            }
            if (Room_number == 113 && Room_letter == "D" && Globals.block_113D == true)
            {
                setButtonState();
                Globals.block_113D = false;
            }
            if (Room_number == 113 && Room_letter == "E" && Globals.block_113E == true)
            {
                setButtonState();
                Globals.block_113E = false;
            }
            if (Room_number == 113 && Room_letter == "F" && Globals.block_113F == true)
            {
                setButtonState();
                Globals.block_113F = false;
            }
            if (Room_number == 113 && Room_letter == "G" && Globals.block_113G == true)
            {
                setButtonState();
                Globals.block_113G = false;
            }


            if (Room_number == 110 && Room_letter == "" && Globals.block_110 == true)
            {
                setButtonState();
                Globals.block_110 = false;
            }
            if (Room_number == 110 && Room_letter == "A" && Globals.block_110A == true)
            {
                setButtonState();
                Globals.block_110A = false;
            }
            if (Room_number == 110 && Room_letter == "B" && Globals.block_110B == true)
            {
                setButtonState();
                Globals.block_110B = false;
            }

            if (Room_number == 111 && Room_letter == "A" && Globals.block_111A == true)
            {
                setButtonState();
                Globals.block_111A= false;
            }
            if (Room_number == 111 && Room_letter == "B" && Globals.block_111B == true)
            {
                setButtonState();
                Globals.block_111B = false;
            }


            if (Room_number == 102 && Room_letter == "" && Globals.block_102 == true)
            {
                setButtonState();
                Globals.block_102 = false;
            }
            if (Room_number == 121 && Room_letter == "" && Globals.block_121 == true)
            {
                setButtonState();
                Globals.block_121 = false;
            }


        }

    }
}