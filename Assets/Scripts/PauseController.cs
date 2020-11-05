using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public Transform inventoryUITransform, pauseText;
    private InventoryUI inventoryUI;
    private bool isPaused, isInvDisplayed;

    // Start is called before the first frame update
    void Start()
    {
        inventoryUI = inventoryUITransform.GetComponent<InventoryUI>();
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
        pauseText.gameObject.SetActive(false);
    }

    private void Pause(){
        pauseText.gameObject.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
    }
    private void DisplayInvenory(){
        isInvDisplayed = true;
        inventoryUITransform.gameObject.SetActive(true);
        pauseText.gameObject.SetActive(false);
        inventoryUI.DrawInventory();
    }
    private void ClearInventoryDisplay(){
        isInvDisplayed = false;
        inventoryUI.clear();
        inventoryUITransform.gameObject.SetActive(false);
    }
}
