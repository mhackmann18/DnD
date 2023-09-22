// /* Terminology:
//  * AC = Armor Class
//  * 
//  *  */
// public class Player 
// {
//   // Ability scores
//   private int dexterityScore = 10;
//   public int DexterityModifier { get => (dexterityScore - 10) / 2; } 
//   private int ACModifier;
//   private Gear gear = new Gear();
//   public int AC {
//     get {
//       int baseAC = gear.Armor ? gear.Armor.BaseAC : 10;
//       int ACModifier = this.ACModifier;
//       if(gear.Armor)
//       {
//         ACModifier += gear.Armor.GetDexterityAC(DexterityModifier);
//       }
//       return baseAC + ACModifier;
//     }
//   }
// }

// public class Gear
// {
//   public Armor Armor { get; set; }
// }
