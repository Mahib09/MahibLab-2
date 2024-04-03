// Define the Cuisine discriminated union
type Cuisine = 
    | Korean 
    | Turkish

// Define the MovieType discriminated union
type MovieType =
    | Regular 
    | IMAX 
    | DBOX 
    | RegularWithSnacks 
    | IMAXWithSnacks 
    | DBOXWithSnacks

// Define the Activity discriminated union
type Activity =
    | BoardGame
    | Chill
    | Movie of MovieType
    | Restaurant of Cuisine
    | LongDrive of int * float

// Function to calculate budget for an activity
let calculateBudget (activity: Activity) =
    match activity with
    | BoardGame -> 0.0
    | Chill -> 0.0
    | Movie movieType ->
        match movieType with
        | Regular -> 12.0
        | IMAX -> 17.0
        | DBOX -> 20.0
        | RegularWithSnacks -> 12.0 + 5.0
        | IMAXWithSnacks -> 17.0 + 5.0
        | DBOXWithSnacks -> 20.0 + 5.0
    | Restaurant cuisine ->
        match cuisine with
        | Korean -> 70.0
        | Turkish -> 65.0
    | LongDrive (kilometres, fuelCharge) -> float kilometres * fuelCharge

// Example usage
let activity1 = Movie RegularWithSnacks
let activity2 = Restaurant Turkish
let activity3 = LongDrive (100, 0.08)

printfn "Budget for Activity 1: %.2f CAD" (calculateBudget activity1)
printfn "Budget for Activity 2: %.2f CAD" (calculateBudget activity2)
printfn "Budget for Activity 3: %.2f CAD" (calculateBudget activity3)

