# WalmartInterview

## Overview

I implemented this problem in C# using a simple algorithm. Assignments were made in a sequential fashion, giving priority to customers who made earlier reservations (ie. came first in the input file). All members of a reservation group are put in the same row. People in different reservation groups were spaced apart by a buffer of 3 seats, or moved to the next row if they cannot fit as a group into the current one. If the movie theater runs out of space, the program does not output assignments for newer reservations.

Tests are written with the xUnit.net framework.

## Assumptions

- Reservation IDs are unique and do not contain spaces.
- The number of people in a reservation group is positive and does not exceed the width of the movie theater (20 seats).
- The order of reservations in the file is from earliest to latest. 

## Instructions to Run / Test

Install the .NET SDK from here: https://dotnet.microsoft.com/download/dotnet It contains the .NET CLI, which is needed to run this app.

Clone this repo, `cd` into the directory and run

```
dotnet run [path_to_input_file]
```

to run the program. To execute tests, run

```
dotnet test
```
