using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainToZone : MonoBehaviour
{

    public void GoToZoneSelector() {
        SceneManager.LoadScene("3dTestScene");
    }

}
