public abstract class PlayerClass 
{
  protected HashSet<string> proficiencies = new HashSet<string>();
  protected int level;

  // abstract property with get accessor for starting profincies and selectablesp

  protected PlayerClass(
    int numStartingProficiencySelections,
    string[] defaultStartingProficiencies, 
    string[] selectableStartingProficiencies)
  {
    // Add default class proficiencies
    proficiencies.UnionWith(defaultStartingProficiencies);

    // User must choose class skill proficiencies
    SelectProficiencies(selectableStartingProficiencies, numStartingProficiencySelections);
  }

  // FIX: You may consider moving this to the Player class
  private void SelectProficiencies(string[] possibleProficiencies, int numSelections)
  {
    SelectionMenu consoleMenu = new SelectionMenu(
      possibleProficiencies,
      $"Choose {numSelections} from the following skill proficiencies",
      "Add selection to your proficiencies?",
      numSelections
    );
    string[] selectedSkillProficiencies = consoleMenu.GetSelections();
    this.proficiencies.UnionWith(selectedSkillProficiencies);
  }
}
