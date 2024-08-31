using UnityEngine;
using UnityEngine.SceneManagement;

public class RotationChecker : MonoBehaviour
{
    public GameObject Picture1; // First object to check
    public GameObject Picture2; // Second object to check
    public GameObject Picture3; // Third object to check
    public GameObject Finish; // Image to activate when all rotations are 0

    void Start()
    {
        Finish.SetActive(false);
    }
    void Update()
    {
        // Check if Z rotation of all objects is zero
        if (IsRotationZero(Picture1) && IsRotationZero(Picture2) && IsRotationZero(Picture3))
        {
            Finish.SetActive(true);
        }
    }

    bool IsRotationZero(GameObject obj)
    {
        return Mathf.Approximately(obj.transform.eulerAngles.z, 0f);
    }

    public void Restart()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
