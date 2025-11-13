using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ARImageTracker : MonoBehaviour
{
    public GameObject contentPrefab;
    private ARTrackedImageManager manager;
    private readonly Dictionary<string, GameObject> spawned = new();

    void Awake() => manager = GetComponent<ARTrackedImageManager>();
    void OnEnable() => manager.trackedImagesChanged += OnChanged;
    void OnDisable() => manager.trackedImagesChanged -= OnChanged;

    void OnChanged(ARTrackedImagesChangedEventArgs e)
    {
        foreach (var added in e.added) UpdateImage(added);
        foreach (var updated in e.updated) UpdateImage(updated);
        foreach (var removed in e.removed) RemoveImage(removed);
    }

    void UpdateImage(ARTrackedImage img)
    {
        string name = img.referenceImage.name;
        if (!spawned.ContainsKey(name))
        {
            var go = Instantiate(contentPrefab, img.transform);
            go.name = "content_" + name;
            spawned[name] = go;
        }
        var obj = spawned[name];
        obj.SetActive(img.trackingState == TrackingState.Tracking);
        obj.transform.SetPositionAndRotation(img.transform.position, img.transform.rotation);
    }

    void RemoveImage(ARTrackedImage img)
    {
        string name = img.referenceImage.name;
        if (spawned.ContainsKey(name))
        {
            Destroy(spawned[name]);
            spawned.Remove(name);
        }
    }
}