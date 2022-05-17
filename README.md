# Ghost Gallery
Final project for EFA Red Badge

## Usage
This program is designed to be able to create a database of different ghosts, locations, and events tied to them for many different genres.

It's designed to be able to both create, edit, grab, and delete items from its database, using SQL code instructions such as Get, Pull, Put, and Delete.

The site is fully capable of handling these requests and able to display them easily as well.

### Location
Locations are individual places where ghosts may be located, and are a stand-alone table, accessed by ghosts.
```csharp
string Name
string Address
```

### Ghost
Ghosts describes a bit more indepth the type of spirits and supernatural elements hunters may be encountering during their work. It has the ability to grab data directly from the Location table.
```csharp
string Name
int? LocationId
string Type
DateTimeOffset FirstSighting
int ThreatLevel
string Appearance
string Description
string Powers
```

### Events
Events describe certain supernatural events that have arrived from Ghosts, detailing equipment used, the event date and time, and which ghost has been documented. 
```csharp
DateTimeOffset EventDate
int? GhostId
string Description
string Equipment
```

## Contributions
At this current state, the project is not open for outside contributions, and is only for use in ElevenFifty Academy and the students/teachers affiliated with the project.


## Downloading
The code and database should all be set to run after copying it in. Once you have, you can either use programs like postmate, or even typing in /swagger at the end to access more ease of use.

It should be noted that individual accounts must be registered beforehand to access, acquiring a token to be able to edit and delete posts. However, posting and retrieving data need no such information.

## Authors
Victor Ryan - All Aspects

Special thanks to Christopher Pettigrew for help and questions along the way

## License
MIT
