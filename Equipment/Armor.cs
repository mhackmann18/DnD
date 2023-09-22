public class Armor : Equipment 
{
  public bool SteathDisadvantage { get; }
  public ArmorCategory Category { get; }
  public string RequiredProficiency { get; }
  public bool IsMetal { get; private set; }
  
  private int baseAC;

  public Armor(
    string name, 
    ArmorCategory category,
    int baseAC,
    double weight, 
    int value,
    bool stealthDisadvantage,
    bool isMetal) : base(name, weight, value)
  {
    baseAC = baseAC;
    Category = category;
    SteathDisadvantage = stealthDisadvantage;
    IsMetal = isMetal;
    if(Category == ArmorCategory.Light)
    {
      RequiredProficiency = "Light Armor";
    }
    else if(Category == ArmorCategory.Medium)
    {
      RequiredProficiency = "Medium Armor";
    }
    else 
    {
      RequiredProficiency = "Heavy Armor";
    }
  }

  public int GetAC(int dexterityModifier)
  {
    if(Category == ArmorCategory.Light)
    {
      return baseAC + dexterityModifier;
    } 
    else if(Category == ArmorCategory.Medium)
    {
      return baseAC + (dexterityModifier >= 2 ? 2 : dexterityModifier);
    } 
    return baseAC;
  }
}

public enum ArmorCategory 
{
  Light, 
  Medium,
  Heavy
}
