using HomeAssistant;
using UnityEngine;
using Newtonsoft.Json.Linq;

public class HALight : ActivationBehaviour
{
    public string entityId;
    public Light sceneLight;
    
    private LightEntity _lightEntity;

    void Start()
    {
        _lightEntity = new LightEntity(entityId);

        if (_lightEntity != null) // found?
        {
            // grab current state
            _lightEntity.IsOn(on =>
            {
                if(sceneLight != null){
                    sceneLight.enabled = on;
                    _lightEntity.GetBrightness(brightness =>{
                        sceneLight.intensity = (brightness * 10);
                        // Debug.Log($"The lamp brightness is {brightness / 255f}");
                    });
                    _lightEntity.GetColor((red,green,blue) => {
                        Color newColor = new Color(red / 255f, green / 255f, blue / 255f, 1f); // Create a new Color object from the RGB values
                        sceneLight.color = newColor; // Assign the new Color to the Light component
                    });}
                    else
                        {
                            sceneLight.intensity = 0;
                        }

            });
        }
    }
private float timer = 0.25f; // set the timer to 1 second

void Update()
{
    timer -= Time.deltaTime; // reduce the timer by the elapsed time since the last frame

    if (timer <= 0f) // if the timer has elapsed
    {
        // execute the code to check the state of the light entity
        if (_lightEntity != null)

        {

            _lightEntity.GetBrightness(brightness =>{
                sceneLight.intensity = (brightness * 10);
                // Debug.Log($"The lamp brightness is {brightness / 255f}");
            });

            _lightEntity.GetColor((red,green,blue) => {
                Color newColor = new Color(red / 255f, green / 255f, blue / 255f, 1f); // Create a new Color object from the RGB values
                sceneLight.color = newColor; // Assign the new Color to the Light component
            });
            // Check if light entity state has changed
            _lightEntity.IsOn(on =>
            {
                if (sceneLight != null)
                {
                    bool isSceneLightActive = sceneLight.enabled;
                    if (on != isSceneLightActive)
                    {
                        sceneLight.enabled = on;


                    }
                }
            });
        }

        timer = 0.25f; // reset the timer to 1 second
    }
}

    public override void OnActivate()
    {
        if (_lightEntity != null)
        {
            _lightEntity.Toggle(on =>
            {
                if (sceneLight != null)
                {   sceneLight.enabled = on;
                    _lightEntity.GetBrightness(brightness =>{
                        sceneLight.intensity = (brightness * 10);
                        // Debug.Log($"The lamp brightness is {brightness / 255f}");
                    });
                    _lightEntity.GetColor((red,green,blue) => {
                        Color newColor = new Color(red / 255f, green / 255f, blue / 255f, 1f); // Create a new Color object from the RGB values
                        sceneLight.color = newColor; // Assign the new Color to the Light component
                    });
                    // sceneLight.SetActive(on);
                }
                
            });
        }
    }
}
