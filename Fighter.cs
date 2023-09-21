public class Fighter : PlayerClass 
{
  private static readonly int numStartingProficiencySelections = 2;
  // Player gets these proficiencies simply by selecting the Fighter class
  private static readonly string[] startingClassProficiencies = {
    Proficiency.LightArmor, 
    Proficiency.MediumArmor,
    Proficiency.HeavyArmor,
    Proficiency.Shields,
    Proficiency.SimpleWeapons,
    Proficiency.MartialWeapons,
    Proficiency.StrengthSavingThrows, 
    Proficiency.ConstitutionSavingThrows
  };

  // Player must choose additional proficiencies from this pool
  private static readonly string[] possibleStartingSkillProficiencies = {
    Proficiency.Acrobatics,
    Proficiency.AnimalHandling,
    Proficiency.Athletics,
    Proficiency.History,
    Proficiency.Insight,
    Proficiency.Intimidation,
    Proficiency.Perception,
    Proficiency.Survival
  };

  // public const int hitDiceSides = 10;
  public Fighter(
    int level
  ) : base(
    numStartingProficiencySelections, 
    startingClassProficiencies, 
    possibleStartingSkillProficiencies)
  {
    this.level = level;
  }
}
