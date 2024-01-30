# Simple REST API
This is example project of making API with ASP.NET Core.

# API interaction

>[!TIP]
>:heavy_check_mark: - provided query is free to use
>:warning: - query in developement and not fully tested
>:x: - query is not implemented or don't work properly

## List of queries for unauthorized access

- ⚠️ GET ```/Puzzle/result?search&page``` - return puzzles by search parameters 
- ⚠️ GET ```/Puzzle/{puzzleId}``` - return puzzle by ```puzzleId```
- ⚠️ GET ```/Brand/result?search&page``` - return brands by search parameters
- ⚠️ GET ```/Brand/{brandId}``` - return brand by ```brandId```
- ⚠️ GET ```/Brand/{brandId}/owned?search&page``` - return puzzles by search parameters that owned by brand with given ```brandId```

## User information
- :x: GET `/User/{userId}` - return public information about user by `userId`
- :x: GET `/User/{userLogin}` - return public information about user by `userLogin`
- :x: GET `/User/{userId}/private` - return private information about user by `userId`, can be managed by account owner, used to making orders
    <details>
      <summary> request body
      </summary>
    
        Content-Type: application/json
        {
          "email": "email",
          "password": "user_password"
        }
    </details>
- :x: GET `/User/{userLogin}/private` - return private information about user by `userLogin`, can be managed by account owner, used to making orders
    <details>
      <summary> request body
      </summary>
    
        Content-Type: application/json
        {
          "email": "email",
          "password": "user_password"
        }
    </details>
## Sign up, managing your account 
- :x: POST `/User/create` - create account providing email and password
    <details>
      <summary> request body
      </summary>
    
        Content-Type: application/json
        {
          "name": "name",
          "surname": "surname",
          "login": "login",
          "email": "email",
          "password": "user_password"
        }
    </details>

- :x: POST `/User/{userId}/update_password` - update account password providing email, old and new password
    <details>
      <summary> request body
      </summary>
    
        Content-Type: application/json
        {
          "email": "email",
          "old-password": "user_password",
          "new-password": "new_user_password",
        }
    </details>
- :x: POST `/User/{userId}/update` - update account password providing email, old and new password
    <details>
      <summary> request body
      </summary>
    
        Content-Type: application/json
        {
          "email": "email",
          "password": "user_password",
          "name": "name",
          "surname": "surname",
          "adress": "adress",
        }
    </details>
## List of queries for managing your brand, requires authorization and to be a brand owner
