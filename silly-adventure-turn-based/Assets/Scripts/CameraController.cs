using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public CinemachineCamera thirdpersonCam;
    public CinemachineCamera dialogueCam;

    private GameStateController GameStateController => GameStateController.Instance;


    public void OnEnable()
    {
        GameStateController.GameStateChanged += GameStateController_GameStateChanged;
    }

    private void OnDisable()
    {
        GameStateController.GameStateChanged -= GameStateController_GameStateChanged;
    }

    private void GameStateController_GameStateChanged(GameState newState)
    {
        switch (newState)
        {
            case GameState.FreeRoam:
                OnEnterFreeRoamState();
                break;
            case GameState.Dialogue:
                OnEnterDialogueState();
                break;
        }
    }

    private void OnEnterFreeRoamState()
    {
        dialogueCam.gameObject.SetActive(false);
    }

    private void OnEnterDialogueState()
    {
        dialogueCam.gameObject.SetActive(true);
    }
}
