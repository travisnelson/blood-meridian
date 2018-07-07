using UnityEngine;
using System.Collections;

public class Config : MonoBehaviour {
	protected Config() {} // don't instantiate

	public const float TILE_WIDTH = 0.08f;
	public const float TILE_HEIGHT = 0.16f;
	public const float ACTOR_Z_DEPTH = -3.8f;

	// combat
	public const float DAMAGE_VARIANCE = 0.25f;
	public const int BAREHAND_DAMAGE = 3;
	public const int INDIAN_SPEAR_DAMAGE = 5;
	public const int KNIFE_DAMAGE = 10;
	public const int KNIFE_COST = 3;
	public const int PISTOL_DAMAGE = 25;
	public const int PISTOL_COST = 7;
	public const int RIFLE_DAMAGE = 50;
	public const int RIFLE_COST = 15;
	public const int HORSE_COST = 1;

	// Camera config
	public const int MIN_X = -4;
	public const int MAX_X = 4;
	public const int MIN_Y = -2;
	public const int MAX_Y = 4;
	public const float MOVEMENT_THRESHOLD_X = 2.4f;
	public const float MOVEMENT_THRESHOLD_Y = 1.5f;
	public const float MAP_MOVEMENT_RATE = 1.5f;

	// hunter config
	public const int INITIAL_HUNTERS = 10;
	public const float HUNTER_MOVEMENT_RATE_WALKING = 0.3f;
	public const float HUNTER_MOVEMENT_RATE_HORSE = 0.5f;
	public const int FIDGET_SPEED_INVERSE = 50;
	public const int EXIT_LOCATION_THRESHOLD = 50;
	public const int HUNTER_MAX_HEALTH = 100;

	// civilians
	public const float POPULATION_VARIANCE = 0.25f;
	public const int GALLEGO_MAX_CITIZENS = 30;
	public const int COYAME_MAX_CITIZENS = 15;
	public const int ENCINILLAS_MAX_CITIZENS = 15;
	public const int JESUS_MARIA_MAX_CITIZENS = 15;
	public const int GALEANA_MAX_CITIZENS = 15;
	public const int CARRIZAL_MAX_CITIZENS = 20;
	public const int URES_MAX_CITIZENS = 10;
	public const int NACOZARI_MAX_CITIZENS = 35;
	public const int JANOS_MAX_CITIZENS = 15;
	public const int HUECOTANKS_MAX_CITIZENS = 10;
	public const int CIVILIAN_FIDGET_SPEED = 10;
	public const int CIVILIAN_TRAVEL_SPEED = 10;

	// indians
	public static Vector3 INDIAN_LOC_1 = new Vector3(3.48f, -3.16f, Config.ACTOR_Z_DEPTH);
	public static Vector3 INDIAN_LOC_2 = new Vector3(3.64f, 1.48f, Config.ACTOR_Z_DEPTH);
	public static Vector3 INDIAN_LOC_3 = new Vector3(-2.52f, 1.64f, Config.ACTOR_Z_DEPTH);
	public static Vector3 COMANCHE_LOC_1 = new Vector3(-6.7f, 5.76f, Config.ACTOR_Z_DEPTH);
	public static Vector3 COMANCHE_LOC_2 = new Vector3(-6.7f, 2.08f, Config.ACTOR_Z_DEPTH);
	public static Vector3 COMANCHE_LOC_3 = new Vector3(1.2f, 5.6f, Config.ACTOR_Z_DEPTH);
	public const int INDIAN_FIDGET_SPEED = 10;

}
