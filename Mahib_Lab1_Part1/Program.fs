type Coach = { Name: string; Experience: int; FormerPlayer: bool }
type Stats = { Wins: int; Losses: int }
type Team = { Name: string; Coach: Coach; Stats: Stats }
let coachesData = [
    { Name = "Quin Snyder"; Experience = 10; FormerPlayer = false }
    { Name = "Darko Rajakovic"; Experience = 0; FormerPlayer = false }
    { Name = "Doc Rivers"; Experience = 23; FormerPlayer = true }
    { Name = "Steve Kerr"; Experience = 10; FormerPlayer = true }
    { Name = "Gregg Popovich"; Experience = 28; FormerPlayer = true }
]
let statsData = [
    { Wins = 35; Losses = 40 }
    { Wins = 23; Losses = 52 }
    { Wins = 15; Losses = 14 }
    { Wins = 41; Losses = 34 }
    { Wins = 18; Losses = 58 }
]
let teams =
    List.zip3 ["Atlanta Hawks"; "Toronto Raptors"; "Milwaukee Bucks"; "Golden State Warriors"; "San Antonio Spurs"]
              coachesData statsData
    |> List.map (fun (name, coach, stats) -> { Name = name; Coach = coach; Stats = stats })
let successfulTeams = teams |> List.filter (fun team -> team.Stats.Wins > team.Stats.Losses)
let successPercentages = successfulTeams |> List.map (fun team -> float team.Stats.Wins / float (team.Stats.Wins + team.Stats.Losses) * 100.0)
printfn "Successful Teams:"
List.iter2 (fun team percentage -> printfn "%s - Success Percentage: %.2f%%" team.Name percentage) successfulTeams successPercentages

