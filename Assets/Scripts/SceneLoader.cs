using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Basic scene loader triggered on the player collision
/// To make scene available for loading enable those in (Editor window) File -> Build Settings... -> Add required scenes
/// </summary>
public class SceneLoader : MonoBehaviour
{
    public int iLevelToLoad;
    public string sLevelToLoad;
    public bool useIntegerToLoadLevel = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Collided object
        GameObject collisionGameObject = collision.gameObject;

        //Trigger scene loading when player hits the object riggidbody
        if (collisionGameObject.name == "Player")
        {
            LoadScene();
        }
    }

    private void LoadScene()
    {
        //if <useIntegerToLoadLevel> enabled, it will load scene based on the scene index, otherwise based on scene name.
        if (useIntegerToLoadLevel)

        {
            SceneManager.LoadScene(iLevelToLoad);
        }
        else
        {
            SceneManager.LoadScene(sLevelToLoad);
        }
    }
}