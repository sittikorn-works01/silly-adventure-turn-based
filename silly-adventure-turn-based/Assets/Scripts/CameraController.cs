using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public CinemachineCamera thirdpersonCam;
    public CinemachineCamera dialogueCam;

    public void FocusOnDialogue()
    {
        thirdpersonCam.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            FocusOnDialogue();
        }
    }
}
