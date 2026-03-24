using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class TrackedImageHandler : MonoBehaviour
{
    public PrefabDatabase Database;
    [SerializeField] private ARPlaneManager planeManager;
    [SerializeField] private Button startButton;
    public void OnTrackedImageChanged(ARTrackablesChangedEventArgs<ARTrackedImage> obj)
    {
        foreach (ARTrackedImage image in obj.added)
            HandleImageDetected(image);
    }

    private void HandleImageDetected(ARTrackedImage image)
    {
        Debug.Log($"Detected: {image.referenceImage.name}");
        Debug.Log($"Tracking State: {image.trackingState}");

        planeManager.enabled = true;
        startButton.gameObject.SetActive(true);   
    }
}
