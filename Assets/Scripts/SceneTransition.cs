using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using CameraControl;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] string currentScene;
    [SerializeField] string nextScene;
    //[SerializeField] VectorValue playerPosition;

    [SerializeField] Vector2 cameraMax;

    [SerializeField] Vector2 cameraMin;
    [SerializeField] Vector3 nextScenePosition;
    private bool triggered = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !triggered)
        {
            // Prevents this from being triggered twice after async calls.
            triggered = true;

            other.gameObject.transform.position = nextScenePosition;
            var cameraController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<BasicCameraController>();
            cameraController.maxPosition = cameraMax;
            cameraController.minPosition = cameraMin;

            SceneManager.UnloadSceneAsync(currentScene);

            SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);
        }
    }    
}
