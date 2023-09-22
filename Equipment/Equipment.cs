public abstract class Equipment {
  // Fields
  private readonly string name;
  private readonly double weight;
  private readonly int value;
  
  // Properties
  public string Name => name;
  public double Weight => weight;
  public int Value => value;

  // value = value in copper pieces
  // weight = weight in pounds
  protected Equipment(string name, double weight, int value) 
  {
    this.name = name;
    this.weight = weight;
    this.value = value;
  }
}
