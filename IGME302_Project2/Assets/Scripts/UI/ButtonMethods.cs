using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMethods : MonoBehaviour
{
    private GameObject currentMenuScreen = null;

    /// <summary>
    /// Loads a scene by index. If <paramref name="index"/> is negative, loads the 
    /// scene (<paramref name="index"/> * -1) scenes ahead of the current scene.
    /// </summary>
    /// <param name="index"></param>
    public void LoadSceneIndex(int index)
    {
        if (index < 0)
        {
            index *= -1;
            index += SceneManager.GetActiveScene().buildIndex;
        }

        SceneManager.LoadScene(index);
    }

    /// <summary>
    /// Quits the game.
    /// </summary>
    public void QuitGame() { Application.Quit(); }

    /// <summary>
    /// Swaps the currently active menu to another menu.
    /// </summary>
    /// <param name="destinationMenuScreen"></param>
    public void SwapMenu(GameObject destinationMenuScreen)
    {
        if (destinationMenuScreen)
        {
            TryInitCurrentMenuScreen();

            currentMenuScreen.SetActive(false);
            destinationMenuScreen.SetActive(true);
            currentMenuScreen = destinationMenuScreen;
        }
    }

    //--- Helper Methods ---//

    /// <summary>
    /// Goes through all of this object's children, and sets currentMenu equal to the first active menu.
    /// This will only happen if currentMenu is not assigned.
    /// </summary>
    /// <param name="transformToCheck">The transform to look in. Defaults to this script's transform.</param>
    /// <returns>Whether currentMenu was assigned or not.</returns>
    private bool TryInitCurrentMenuScreen(Transform transformToCheck = null)
    {
        //Only get the current menu if currentMenu is uninitialized / null.
        if (!currentMenuScreen)
        {
            //If transformToCheck is null, use this script's transform instead. Otherwise, just use transformToCheck.
            transformToCheck = transformToCheck ? transformToCheck : transform;

            //For each child of this object,
            foreach (Transform child in transformToCheck)
            {
                //Check if its active. (We don't need to check its children, because they'll be inactive if this
                //is inactive.)
                if (child.gameObject.activeInHierarchy)
                {
                    //If it is, and it's a menu, we found the first active menu. Set currentMenu equal to it.
                    if (child.CompareTag("MenuScreen"))
                    {
                        currentMenuScreen = child.gameObject;
                        return true;
                    }
                    //If it's not a menu, it's a container; check all of its children, and if we find
                    //a menu when we do, return true.
                    else
                    {
                        if (TryInitCurrentMenuScreen(child)) { return true; }
                    }
                }
            }
        }

        //If we made it this far, currentMenu is already assigned, or no active menu was found.
        return false;
    }
}