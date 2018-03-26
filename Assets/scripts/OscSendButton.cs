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
    public class OscSendButton : UniOSCEventDispatcher
    {
        public int button_id;

        public Texture myTexture_on;
        public Texture myTexture_off;

        private Material myNewMaterial;
        private string msg_on = ";on";
        private string msg_off = ";off";

        private static List<string> state = new List<string>();

        public override void Awake()
        {
            //Find the Standard Shader
            myNewMaterial = new Material(Shader.Find("Standard"));
            //Set Texture on the material
            myNewMaterial.SetTexture("_MainTex", myTexture_off);
            //Apply to GameObject
            GetComponent<MeshRenderer>().material = myNewMaterial;

            for (int i = 0; i < 130; i = i + 1)
            {
                state.Add("off");
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
            string msg = button_id.ToString();

            if (state[button_id] == "on")
            {
                myNewMaterial.SetTexture("_MainTex", myTexture_off);
                GetComponent<MeshRenderer>().material = myNewMaterial;
                msg += msg_off;
                SendOSC(msg);
                state[button_id] = "off";
                Debug.Log(msg);
            }
            else
            {
                myNewMaterial.SetTexture("_MainTex", myTexture_on);
                GetComponent<MeshRenderer>().material = myNewMaterial;
                msg += msg_on;
                SendOSC(msg);
                state[button_id] = "on";
                Debug.Log(msg);
            }
        }

        void OnMouseDown()
        {
            Debug.Log("Buton:OnTouchDown");
            string msg = button_id.ToString();

            if (state[button_id] == "on")
            {
                myNewMaterial.SetTexture("_MainTex", myTexture_off);
                GetComponent<MeshRenderer>().material = myNewMaterial;
                msg += msg_off;
                SendOSC(msg);
                state[button_id] = "off";
                Debug.Log(msg);
            }
            else
            {
                myNewMaterial.SetTexture("_MainTex", myTexture_on);
                GetComponent<MeshRenderer>().material = myNewMaterial;
                msg += msg_on;
                SendOSC(msg);
                state[button_id] = "on";
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
            Debug.Log("Buton:OnTouchExit");
            string msg = button_id.ToString();
            if (state[button_id] == "on")
            {
                myNewMaterial.SetTexture("_MainTex", myTexture_off);
                GetComponent<MeshRenderer>().material = myNewMaterial;
                msg += msg_off;
                SendOSC(msg);
                state[button_id] = "off";
                Debug.Log(msg);
            }
            else
            {
                myNewMaterial.SetTexture("_MainTex", myTexture_on);
                GetComponent<MeshRenderer>().material = myNewMaterial;
                msg += msg_on;
                SendOSC(msg);
                state[button_id] = "on";
                Debug.Log(msg);
            }
        }

    }
}