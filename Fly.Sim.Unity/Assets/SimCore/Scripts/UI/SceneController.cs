using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
   public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
