using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public delegate void Notify();
    public Notify onDialog, onPause, onUnpause, onInventoryDisplay, onInventoryClear;

    private bool isPaused, isInvDisplayed;


    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i")){
            if(isInvDisplayed){
                ClearInventoryDisplay();
                Unpause();
            }
            else{
                Pause();
                DisplayInvenory();
            }
        }

        if (Input.GetKeyDown("p")){
            if(isPaused){
                Unpause();
            }
            else{
                Pause();
            }
            if(isInvDisplayed){
                ClearInventoryDisplay();
            }
        }

    }

    private void Unpause(){
        isPaused = false;
        Time.timeScale = 1;
        onUnpause?.Invoke();
    }

    private void Pause(){
        onPause?.Invoke();
        isPaused = true;
        Time.timeScale = 0;
    }
    private void DisplayInvenory(){
        isInvDisplayed = true;
        onInventoryDisplay?.Invoke();
    }
    private void ClearInventoryDisplay(){
        isInvDisplayed = false;
        onInventoryClear?.Invoke();
    }
}
