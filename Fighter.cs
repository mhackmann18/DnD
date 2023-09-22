public class Fighter : PlayerClass 
{
  private static string[] defaultStartingProficiencies = new string[]
  {
    Proficiency.LightArmor, 
    Proficiency.MediumArmor,
    Proficiency.HeavyArmor,
    Proficiency.Shields,
    Proficiency.SimpleWeapons,
    Proficiency.MartialWeapons,
    Proficiency.StrengthSavingThrows, 
    Proficiency.ConstitutionSavingThrows
  };

  public override string[] DefaultStartingProficiencies { get => defaultStartingProficiencies; }

  private static string[] startingProficiencyOptions = new string[]
  {
    Proficiency.Acrobatics,
    Proficiency.AnimalHandling,
    Proficiency.Athletics,
    Proficiency.History,
    Proficiency.Insight,
    Proficiency.Intimidation,
    Proficiency.Perception,
    Proficiency.Survival
  };

  public override string[] StartingProficiencyOptions { get => startingProficiencyOptions; }

  public override string[][] StartingEquipmentOptionGroups { get {
    string[][] startingEquipmentOptions = new string[4][];
    startingEquipmentOptions[0] = new string[] { "Chain Mail", "Leather Armor" };
    startingEquipmentOptions[1] = new string[] { "Chain Mail", "Leather Armor" };
    startingEquipmentOptions[2] = new string[] { "Chain Mail", "Leather Armor" };
    startingEquipmentOptions[3] = new string[] { "Chain Mail", "Leather Armor" };
    return startingEquipmentOptions;
  }}

  public override int NumStartingProficiencySelections { get => 2; }

  // public const int hitDiceSides = 10;
  public Fighter(int level) : base()
  {
    this.level = level;
  }
}
