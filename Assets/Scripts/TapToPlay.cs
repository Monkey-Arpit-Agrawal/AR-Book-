using UnityEngine;
public class TapToPlay : MonoBehaviour
{
    AudioSource src;
    void Start() => src = GetComponent<AudioSource>();
    void OnMouseDown() { if (src && !src.isPlaying) src.Play(); }
}