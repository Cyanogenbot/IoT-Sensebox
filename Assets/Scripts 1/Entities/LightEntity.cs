
using System;
using UnityEngine;
using Newtonsoft.Json.Linq;

namespace HomeAssistant
{
    public class LightEntity : Entity
    {
        public LightEntity(string entityId) : base("light", entityId)
        {
            if (!Id.StartsWith("light."))
                Id = "light." + Id;
        }

        public void IsOn(Action<bool> handler = null) => GetState(result => handler?.Invoke(result?.State == "on"));

        public void GetBrightness(Action<int> handler = null){
            GetState(result => {
            
                if (result?.State == "on" && result.Attributes.ContainsKey("brightness")){
                   var brightnessValue = result.Attributes["brightness"];
                       if (brightnessValue is long || brightnessValue is int) {
                            int brightness = Convert.ToInt32(brightnessValue);
                    // int brightness = (int)result.Attributes["brightness"];
                    
                    Debug.Log($"The lamp brightness is {brightness}");
                    handler?.Invoke(brightness);}


                    // if (data != null && data.Count > 0) {
                    //     int brightness = (int)data[0];
                    //     Debug.Log($"The lamp brightness is {brightness}");
                    //     handler?.Invoke(brightness);
                    // }
                }
            });
        }

        public void GetColor(Action<int, int,int> handler = null)
        {
            GetState(result => {
                //  rgbColors = null;
                // Debug.Log($"The lamp is {result.Attrubtes as string}");
                if (result?.State == "on" && result.Attributes.ContainsKey("rgb_color"))
                {
                    // rgbColor = result.Attributes["rgb_color"] as JArray;
                    // int red = (int)rgbColor[0];

                    JArray rgbColor = result.Attributes["rgb_color"] as JArray;
                    if (rgbColor != null && rgbColor.Count == 3)
                    {
                        int red = (int)rgbColor[0];
                        int green = (int)rgbColor[1];
                        int blue = (int)rgbColor[2];
                        // Debug.Log($"The lamp is containing a key{blue}");
                        // Do something with the red, green, and blue values
                        handler?.Invoke(red, green, blue);
                    }

                    // color = colorObj as string;
                    // rgbColors = rgbColor;
                    
                }

                

            });
        }



        public void TurnOn() => CallService("turn_on");
        
        public void TurnOff() => CallService("turn_off");
        public void Toggle(Action<bool> handler = null) => IsOn(on =>
        {
            if (on) TurnOff();
            else TurnOn();

            handler?.Invoke(!on);
        });
    }
}
