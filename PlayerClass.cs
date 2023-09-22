public abstract class PlayerClass 
{
  protected int level;
  public abstract string[] DefaultStartingProficiencies { get; } // instead of string, should be Proficiency
  public abstract string[] StartingProficiencyOptions { get; }
  public abstract string[][] StartingEquipmentOptionGroups { get; }
  public abstract int NumStartingProficiencySelections { get; }

  // abstract static private property with get accessor for starting profincies and selectablesp

  protected PlayerClass()
  {
    // Roll for HP (depends on level, hit dice, and constitution) - Player?

    // Choose class skill proficiencies
    SelectProficiencies(StartingProficiencyOptions, NumStartingProficiencySelections);

    // Choose class equipment
    SelectEquipment(StartingEquipmentOptionGroups);

    // Choose class spells

    // Choose class features
  }

  // FIX: You may consider moving this to the Player class
  private string[] SelectProficiencies(string[] proficiencyOptions, int numSelections)
  {
    SelectionMenu optionsMenu = new SelectionMenu(
      proficiencyOptions,
      $"Choose {numSelections} from the following skill proficiencies",
      "Add selection to your proficiencies?",
      numSelections
    );
    return optionsMenu.GetSelections();
  }

  private string[] SelectEquipment(string[][] equipmentOptionGroups)
  {
    string[] equipmentSelections = new string[equipmentOptionGroups.Length];
    for(int i = 0; i < equipmentOptionGroups.Length; i++)
    {
      SelectionMenu equipmentMenu = new SelectionMenu(
        equipmentOptionGroups[i],
        "Choose one of the following equipment options"
      );
      string[] selectedEquipment = equipmentMenu.GetSelections();
      equipmentSelections[i] = selectedEquipment[0];
    }
    return equipmentSelections;
  }
}
