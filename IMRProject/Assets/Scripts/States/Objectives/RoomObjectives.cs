using UnityEngine;

[CreateAssetMenu(fileName = "RoomObjectives", menuName = "Custom/RoomObjectives")]
public class RoomObjectives : ScriptableObject
{
    [TextArea]
    public string startMessage = "Welcome to the room!";

    [TextArea]
    public string endMessage = "Congratulations! Room objectives completed!";
}