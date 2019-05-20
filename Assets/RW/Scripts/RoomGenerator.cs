using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour {

    public GameObject[] availableRooms;
    public List<GameObject> currentRooms;
    private float screenWidthInPoints;

	// Use this for initialization
	void Start () {

        float height = 2.0f * Camera.main.orthographicSize;
        screenWidthInPoints = height * Camera.main.aspect;

        StartCoroutine(GeneratorCheck());
    }

    void AddRoom(float farthestRoomEndX)
    {
        //1 Picks random room
        int randomRoomIndex = Random.Range(0, availableRooms.Length);
        //2 creates a room for the index chosen
        GameObject room = (GameObject)Instantiate(availableRooms[randomRoomIndex]);
        //3 room's width indicated by floor
        float roomWidth = room.transform.Find("floor").localScale.x;
        //4 Calculates the farthest edge of the level so far and adds
        //half of the new room's width
        float roomCenter = farthestRoomEndX + roomWidth * 0.5f;
        //5 sets position of room
        room.transform.position = new Vector3(roomCenter, 0, 0);
        //6 Add thw room to the list of current rooms
        currentRooms.Add(room);

    }

    private void GenerateRoomIfRequired()
    {
        //Creates a list of rooms to be removed
        List<GameObject> roomsToRemove = new List<GameObject>
    ();
        bool addRooms = true; // indicates when a rooms needs to be added
        float playerX = transform.position.x; // saves player position
        float removeRoomX = playerX - screenWidthInPoints; // Point after which room is removed
        float addRoomX = playerX + screenWidthInPoints; // If there's no room after addRoomX point, you need to add room
        float farthestRoomEndX = 0;  // where you store the point where lvl ends

        foreach (var room in currentRooms)
        // Finds starting point and ending point of room using room width
        {
            float roomWidth = room.transform.Find("floor").localScale.x;
            float roomStartX = room.transform.position.x - (roomWidth * 0.5f);
            float roomEndX = roomStartX + roomWidth;

            if (roomStartX > addRoomX) // don't need to add room if room starts after addRoomX point
            {
                addRooms = false;
            }

            if (roomEndX < removeRoomX) // removes room that ends left of removeRoomX point
            {
                roomsToRemove.Add(room);
            }

            farthestRoomEndX = Mathf.Max(farthestRoomEndX, roomEndX);

        }

        foreach (var room in roomsToRemove)
        {
            currentRooms.Remove(room);
            Destroy(room);
        }

        if (addRooms)
        {
            AddRoom(farthestRoomEndX);
        }
    }

    private IEnumerator GeneratorCheck()
    {
        while (true)
        {
            GenerateRoomIfRequired();
            // pauses for 0.25s 
            yield return new WaitForSeconds(0.25f);
        }
    }

    // Update is called once per frame
    void Update ()
        {

        }  

}
