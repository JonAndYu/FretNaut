# FretNaut API

For local development,
CORS services were added to help with local development.

FretNaut is my way of combining my knowledge (computer science) with my passion (guitar) and forcing myself to learn a bit more about music. I've been stagnant in my music theory lessosn so as I gain a better understanding I hope to update this api with relevant topics. Currently it's base functionality allows an individual to request a tuning and be given the notes up to the 12th fret on a stringed instrument. Often when you search for ntoes on a fretboard you only see images of guitars in standard tuning.
![image](https://github.com/JonAndYu/FretBoardViz/assets/64448283/f9ffd5ae-bb3b-4983-a9d9-ffd705facf7a)

This api will allow beginner guitarists to gain a better understanding on note placements.

Currently the api is published on https://fretnaut.azurewebsites.net/ and will remain avaliable until my Azure trial runs out.


## Introduction
FretNaut is an API that provides a gateway to an array of musical possibilities. 
With FretNaut, you can input tuning information and obtain the corresponding notes on the fretboard, aiding your musical journey and creativity.



# API Documentation

### Endpoints
1. Get All Fretboards
```
URL: https://fretnaut.azurewebsites.net/api/fretboard
Method: GET
Description: Retrieve all available fretboards.
Response:
Status: 200 OK
Content: A list of fretboards.
```
2. Get Fretboard by Tuning
```
URL: https://fretnaut.azurewebsites.net/api/fretboard/GetFretboard/{id}
Method: GET
Description: Retrieve the fretboard for a specific tuning.
Parameters:
id: The tuning identifier. Must be valid Musical Notes or Sharp (EADGBE)
Response:
Status: 200 OK
Content: The fretboard for the specified tuning.
```
3. Create Fretboard
```
URL: https://fretnaut.azurewebsites.net/api/fretboard/createfretboard/{str}
Method: POST
Description: Create a new fretboard for the given tuning.
Parameters:
str: The tuning information. Must be valid Musical Notes or Sharp (EADGBE)
Response:
Status: 200 OK
Content: Success message indicating the fretboard creation.
```
4. Delete Fretboard
```
URL: https://fretnaut.azurewebsites.net/api/fretboard/DeleteFretboard/{str}
Method: DELETE
Description: Delete the fretboard for the given tuning.
Parameters:
str: The tuning information. Must be valid Musical Notes or Sharp (EADGBE)
Response:
Status: 200 OK
Content: Success message indicating the fretboard deletion.
```
5. Get Fretboard Notes
```
URL: https://fretnaut.azurewebsites.net/api/fretboard/notes/{str}
Method: GET
Description: Get the notes for the specified tuning.
Parameters:
str: The tuning information.
Response:
Status: 200 OK
Content: The notes for the specified tuning.
```
## Usage
Get All Fretboards:

Use the endpoint GET /api/fretboard to retrieve a list of all available fretboards.

Result:
```json
[
  {
    "tuningValues": "EADGBE",
    "notes": "
      [
        ["E", "F", "F#"... "E"],
        ["A", "A#", "B"... "A"],
        ...
        ["E", "F", "F#"... "E"]
      ]"
  },
  {
    "tuningValues": "DADGBE",
    "notes": "
      [
        ["D", "D#", "E"... "D"],
        ["A", "A#", "B"... "A"],
        ...
        ["E", "F", "F#"... "E"]
      ]"
  },
  ...
]
```

Use the endpoint GET /api/fretboard/GetFretboard/{id} to obtain the fretboard for a specific tuning.

Input: `/api/fretboard/GetFretboard/EADGBE`
Result: 
```json
{
  "tuningValues": "EADGBE",
  "notes": "
  [
    ["E", "F", "F#", "G", "G#", "A", "A#", "B", "C", "C#", "D", "D#", "E"],
    ["A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A"],
    ["D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B", "C", "C#", "D"],
    ["G", "G#", "A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G"],
    ["B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"],
    ["E", "F", "F#", "G", "G#", "A", "A#", "B", "C", "C#", "D", "D#", "E"]
  ]"
}
```

Use the endpoint GET /api/fretboard/notes/{str} to get the notes for the specified tuning.
Input: `/api/fretboard/notes/EADGBE`
Result:
```json
[
  ["E", "F", "F#", "G", "G#", "A", "A#", "B", "C", "C#", "D", "D#", "E"],
  ["A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A"],
  ["D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B", "C", "C#", "D"],
  ["G", "G#", "A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G"],
  ["B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"],
  ["E", "F", "F#", "G", "G#", "A", "A#", "B", "C", "C#", "D", "D#", "E"]
]
```

Let the music play, and explore the fretboard with FretNaut!
