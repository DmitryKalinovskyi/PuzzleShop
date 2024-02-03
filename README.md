# Simple REST API
This is example project of making API with ASP.NET Core.

# API interaction

>[!TIP]
>✔️ - provided query is free to use
>⚠️ - query in developement or not fully tested
>❌ - query is not implemented or don't work properly

## List of queries for unauthorized access

- ✔️ GET ```/Puzzle/result?search&page``` - return puzzles by search parameters 
- ✔️ GET ```/Puzzle/{puzzleId}``` - return puzzle by ```puzzleId```
- ✔️ GET ```/Brand/result?search&page``` - return brands by search parameters
- ✔️ GET ```/Brand/{brandId}``` - return brand by ```brandId```
- ✔️ GET ```/Brand/{brandId}/owned?search&page``` - return puzzles by search parameters that owned by brand with given ```brandId```

## User information
- ✔️ GET `/User/{userId}` - return public information about user by `userId`
- ✔️ GET `/User/{userLogin}` - return public information about user by `userLogin`
- ✔️ GET `/User/{userId}/private` - return private information about user by `userId`, can be managed by account owner, used to making orders
    <details>
      <summary> request body
      </summary>
    
        Content-Type: application/json
        {
          "email": "email",
          "password": "user_password"
        }
    </details>
- ✔️ GET `/User/{userLogin}/private` - return private information about user by `userLogin`, can be managed by account owner, used to making orders
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
- ✔️ POST `/User/create` - create account providing email and password
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

- ✔️ POST `/User/{userId}/update_password` - update account password providing email, old and new password
    <details>
      <summary> request body
      </summary>
    
        Content-Type: application/json
        {
          "new-password": "new_user_password",
          "email": "email",
          "password": "user_password"
        }
    </details>
- ✔️ POST `/User/{userId}/update` - update account password providing email, old and new password
    <details>
      <summary> request body
      </summary>
    
        Content-Type: application/json
        {
          "name": "name",
          "surname": "surname",
          "login": "login",
          "address": "address",
          "email": "email",
          "password": "user_password"
        }
    </details>
- ✔️ DELETE `/User/{userId}/delete` - deleting account from database
    <details>
      <summary> request body
      </summary>
    
        Content-Type: application/json
        {
          "email": "email",
          "password": "user_password"
        }
    </details>
## List of queries for managing your puzzles
- ✔️  POST `/Puzzle/create` - create puzzle providing email and password
    <details>
      <summary> request body
      </summary>
    
        Content-Type: application/json
        {
          "name": "name",
          "description": "description",
          "image_url": "image_url",
          "price": "price",
          "amount": "amount",
          "brand_id": "brand_id"
          "email": "email",
          "password": "user_password"
        }
    </details>

- ✔️  POST `/Puzzle/{puzzleId}/update` - update puzzle providing email and password
    <details>
      <summary> request body
      </summary>
    
        Content-Type: application/json
        {
          "name": "name",
          "description": "description",
          "image_url": "image_url",
          "price": "price",
          "amount": "amount",
          "brand_id": "brand_id"
          "email": "email",
          "password": "user_password"
        }
    </details>

- ✔️ POST `/Puzzle/{puzzleId}/delete` - delete puzzle providing email and password
    <details>
      <summary> request body
      </summary>
    
        Content-Type: application/json
        {
          "email": "email",
          "password": "user_password"
        }
    </details>
    
## List of queries for managing your brand, requires authorization and to be a brand owner
- ✔️  POST `/Brand/create` - create brand providing email and password
    <details>
      <summary> request body
      </summary>
    
        Content-Type: application/json
        {
          "name": "name",
          "description": "description",
          "email": "email",
          "password": "user_password"
        }
    </details>
- ✔️ POST `/Brand/{brandId}/update` - update brand providing email and password
    <details>
      <summary> request body
      </summary>
    
        Content-Type: application/json
        {
          "name": "name",
          "description": "description",
          "email": "email",
          "password": "user_password"
        }
    </details>
- ✔️ POST `/Brand/{brandId}/delete` - delete brand providing email and password
    <details>
      <summary> request body
      </summary>
    
        Content-Type: application/json
        {
          "email": "email",
          "password": "user_password"
        }
    </details>
