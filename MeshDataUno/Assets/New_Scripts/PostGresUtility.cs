using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class PostGresUtility {

	public static Vector3 parseLocation(string location_string){

		Match Digit1temp = Regex.Match (location_string, "[(][0-9]*[,]");
		string Digit1tempString = (string) Digit1temp.ToString();
		Match Digit1Out = Regex.Match (Digit1tempString, "[0-9]+");
		string Digit1OutString = (string) Digit1Out.ToString();

		Match Digit2temp = Regex.Match (location_string, "[,][0-9]*[,]");
		string Digit2tempString = (string)Digit2temp.ToString ();
		Match Digit2Out = Regex.Match (Digit2tempString, "[0-9]+");
		string Digit2OutString = (string)Digit2Out.ToString ();

		Match Digit3temp = Regex.Match (location_string, "[,][0-9]*[)]");
		string Digit3tempString = (string)Digit3temp.ToString ();
		Match Digit3Out = Regex.Match (Digit3tempString, "[0-9]+");
		string Digit3OutString = (string)Digit3Out.ToString ();

		float Digit1Float = float.Parse (Digit1OutString);
		float Digit2Float = float.Parse (Digit2OutString);
		float Digit3Float = float.Parse (Digit3OutString);

		Vector3 outputVector = new Vector3 (Digit1Float, Digit2Float, Digit3Float);

		return outputVector;
		                             

	}
}
