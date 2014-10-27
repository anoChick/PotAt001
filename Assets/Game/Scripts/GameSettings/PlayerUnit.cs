using UnityEngine;
using System.Collections;

public partial class GameSettings  {
	public static class PlayerUnits {
		public enum UNIT_NO {
			Suika,
			Retasu,
			Jaga,
			Kabocha,
			Negi,
			Nasu
		};

		public static readonly int[] UNIT_COST = new int[]{
			20,25,30,40,70,100
		};

		public static readonly string[] UNIT_CODENAME = new string[]{


			"Vege2",
			"Vege3",
			"Vege4",
			"Vege1",
			"Vege5",
			"Vege6"

		};


	}
}
