using Cinemachine;
using UnityEngine.UI;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook freeLook;

    [Header("Slider Camera Settings")]
    [SerializeField] private Slider slider_YAxis_Sensitivity;
    [SerializeField] private Slider slider_XAxis_Sensitivity;
    [SerializeField] private Slider slider_FOV;


    public void SensitivityYAxis()
    {
        freeLook.m_YAxis.m_MaxSpeed = slider_YAxis_Sensitivity.value;
    }

    public void SensitivityXAxis()
    {
        freeLook.m_XAxis.m_MaxSpeed = slider_XAxis_Sensitivity.value;
    }

    public void InvertYAxis(bool isInvert)
    {
        freeLook.m_YAxis.m_InvertInput = isInvert;
    }

    public void InvertXAxis(bool isInvert)
    {
        freeLook.m_XAxis.m_InvertInput = isInvert;
    }

    public void FOVCamera()
    {
        freeLook.m_Lens.FieldOfView = slider_FOV.value;
    }
}
