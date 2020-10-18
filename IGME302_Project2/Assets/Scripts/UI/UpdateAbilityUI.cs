using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateAbilityUI : MonoBehaviour
{
    [SerializeField] private Image[] abilityIcons = null;
    [SerializeField] private TextMeshProUGUI[] abilityUsageText = null;
    [SerializeField] private Sprite fallbackImage = null;

    private void Awake()
    {
        LevelManager.OnLoaded += UpdateAbilities;
        Player.UseAbility += UpdateUsages;
    }
    private void OnDestroy()
    {
        LevelManager.OnLoaded -= UpdateAbilities;
        Player.UseAbility -= UpdateUsages;
    }

    private void UpdateAbilities(Level loadedLevel)
    {
        //Reactivate each ability in preparation to deactivate the ones we don't need.
        foreach (Image icon in abilityIcons) { icon.gameObject.SetActive(true); }

        //We want to deactivate all of the unused indices. If the ability set has 2 abilities in it, index 2 is 
        //the first index that isn't used.
        int firstInactiveIndex = loadedLevel.abilitySet.Length;

        for (int i = 0; i < abilityIcons.Length; i++)
        {
            //If this index is used, set its icon and usages.
            if (i < firstInactiveIndex)
            {
                Ability correspondingAbility = loadedLevel.abilitySet[i].ability;

                //If the corresponding ability icon is null, replace the ability's sprite with a fallback image.
                abilityIcons[i].sprite = correspondingAbility.icon ? correspondingAbility.icon : fallbackImage;

                abilityUsageText[i].text = loadedLevel.abilitySet[i].usages.ToString();
            }
            //If it's not, deactivate it.
            else { abilityIcons[i].gameObject.SetActive(false); }
        }
    }

    private void UpdateUsages(Ability usedAbility, int abilityIndex)
    {
        abilityUsageText[abilityIndex].text = usedAbility.usagesLeft.ToString();
    }
}
