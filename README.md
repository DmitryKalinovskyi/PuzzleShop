# Simple REST API
This is example project of making API with ASP.NET Core

# API interaction

>[!TIP]
>:heavy_check_mark: - provided query is free to use
>:warning: - query in developement and not fully tested
>:x: - query is not implemented or don't work properly

## List of queries for unauthorized access

- :heavy_check_mark: GET ```/Puzzle/result?search&page``` - return puzzles by search parameters 
- :heavy_check_mark: GET ```/Puzzle/{puzzleId}``` - return puzzle by ```puzzleId```
- :heavy_check_mark: GET ```/Brand/result?search&page``` - return brands by search parameters
- :heavy_check_mark: GET ```/Brand/{brandId}``` - return brand by ```brandId```
- :heavy_check_mark: GET ```/Brand/{brandId}/owned?search&page``` - return puzzles by search parameters that owned by brand with given ```brandId```

## User information
- :x: GET ```/User/{userId}``` - return public information about user by ```userId```
- :x: GET ```/User/{userId}/privat``` - return privat information about user by ```userId```, can be managed by account owner, used to making orders

## Sign up, managing your account 

- :x: POST ```/User/auth```
```
Content-Type: application/json
{
  "email": "email",
  "password": "user_password"
}
```

## List of queries for managing your brand, requires authorization and to be a brand owner

- :heavy_check_mark:```/Puzzle/result?search&page``` - return puzzles by search parameters 

