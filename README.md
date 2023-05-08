# Labb4-API

Get All Users

Request
/GetAllUsers
curl -X 'GET' \
  'https://localhost:7013/GetAllUsers' \
  -H 'accept: */*'
 
 Response
  [
    {
        "id": 1,
        "firstName": "Peter",
        "lastName": "Ingvarsson",
        "phone": "070252542"
    },
    {
        "id": 2,
        "firstName": "Adrian",
        "lastName": "Lundell",
        "phone": "070632175"
    },
    {
        "id": 3,
        "firstName": "Sam",
        "lastName": "Svensson",
        "phone": "070154323"
    }
]

Get Interests by users ID

Request
/GetUsersInterests
curl -X 'GET' \
  'https://localhost:7013/api/Interest/3/GetUsersInterests' \
  -H 'accept: */*'

Response
  [
  {
    "interestID": 3,
    "name": "Surfing",
    "interestDesc": "Riding a board on waves in the water"
  },
  {
    "interestID": 4,
    "name": "Snowboarding",
    "interestDesc": "Riding a board on snow"
  }
]

Get Links to Interests by users ID

Request
curl -X 'GET' \
  'https://localhost:7013/api/UserInterest/GetUsersLinks/3' \
  -H 'accept: */*'

Response
[
    {
        "link": "https://en.wikipedia.org/wiki/Surfing"
    },
    {
        "link": "https://en.wikipedia.org/wiki/Snowboarding"
    },
    {
        "link": "Pls pog"
    }
]

Link a user to a another interest
/UserToNewInterest

Request
curl -X 'POST' \
  'https://localhost:7013/UserToNewInterest' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "userID": 2,
  "interestID": 3
}'

Response
{
  "userInterestID": 6,
  "userID": 2,
  "interestID": 3
}

Add a new link to a specific interest for a specific user
/AddLink

Request
curl -X 'POST' \
  'https://localhost:7013/AddLink?newlink=Woo&userid=3&interestid=4' \
  -H 'accept: */*' \
  -d ''

Response
{
  "link": "Woo"
}
