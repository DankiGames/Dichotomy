using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class resolution : MonoBehaviour
{
    //[SerializeField] private TMP_Dropdown resolutionDropDown;
    //private Resolution[] resolutions;
    //private List<Resolution> filteredResolutions;

    //private float currentRefreshRate;
    //private int currentResolutionIndex = 0;

    public TMP_Dropdown resolutionDropDown;
    Resolution[] resolutions;


    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropDown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();

        //filteredResolutions = new List<Resolution>();

        //resolutionDropDown.ClearOptions();

        //currentRefreshRate = (float)Screen.currentResolution.refreshRateRatio.value;

        //Debug.Log("Resolution:  " + currentRefreshRate);
        //for (int i = 0; i < resolutions.Length; i++)
        //{
        //    Debug.Log("Resolution:  " + resolutions[i]);
        //    if (resolutions[i].refreshRateRatio.value == currentRefreshRate)
        //    {
        //        filteredResolutions.Add(resolutions[i]);
        //    }
        //}

        //List<string> options = new List<string>();

        //for (int i = 0; i < filteredResolutions.Count; i++)
        //{
        //    string resolutionOption = filteredResolutions[i].width + "x" + filteredResolutions[i].height + " " + filteredResolutions[i].refreshRateRatio.value + " Hz";
        //    options.Add(resolutionOption);
        //    if ((resolutions[i].width == Screen.currentResolution.width) &&
        //        (resolutions[i].height == Screen.currentResolution.height))
        //    {
        //        currentResolutionIndex = i;
        //    }
        //}

        //resolutionDropDown.AddOptions(options);
        //resolutionDropDown.value = currentResolutionIndex;
        //resolutionDropDown.RefreshShownValue();

    }
    public void SetResolution(int resolutionIndex)
    {
        //Resolution resolution = filteredResolutions[resolutionIndex];
        //Screen.SetResolution(resolution.width, resolution.height, true);
    }


}
