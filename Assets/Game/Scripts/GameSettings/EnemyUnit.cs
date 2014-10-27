using UnityEngine;
using System.Collections;

public partial class GameSettings  {
	public static class EnemyUnits {
		public enum UNIT_NO {
			Suika,
			Retasu,
			Jaga,
			Kabocha,
			Negi,
			Nasu
		};

		public static readonly int[] UNIT_COST = new int[]{
			10,15,20,30,40,50
		};

		public static readonly string[] UNIT_CODENAME = new string[]{


			"Vege2",
			"retasu",
			"jagaimo",
			"Vege1",
			"Vege5",
			"Vege6"

		};


	}
}
