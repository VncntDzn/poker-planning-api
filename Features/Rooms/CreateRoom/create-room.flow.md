## Create Room

### Trigger
User clicks "Create Room".

### Actors
- User
- Frontend
- API
- Auth middleware
- Room service
- PostgreSQL

### Preconditions
- User is authenticated.
- Request contains valid room settings.
- User account is active.

### Main Path
1. Frontend sends `POST /rooms`.
2. API validates JWT/session.
3. API validates request DTO.
4. API resolves authenticated `UserId`.
5. API creates `Room`.
6. API creates `RoomParticipant` for the owner.
7. API commits both records in one transaction.
8. API returns `roomId`, `joinCode`, and owner participant state.
9. Frontend navigates to `/rooms/{roomId}`.

### State Changes
Creates:

```text
Room
- Id
- Name
- OwnerUserId
- JoinCode
- Status
- CreatedAtUtc

RoomParticipant
- Id
- RoomId
- UserId
- Role = Owner
- JoinedAtUtc
```
### Invariants

* A room must have exactly one owner.
* The owner must also be a participant.
* Room.JoinCode must be unique.
* A closed room cannot accept joins or votes.
* A room cannot exist without a valid owner.

### Failure Modes

* Unauthenticated user → 401
* Invalid DTO → 400
* User not found / disabled → 403
* Join code collision → regenerate and retry
* Duplicate create request → handle with idempotency key or tolerate duplicate rooms intentionally
* DB write failure → rollback
* Room created but participant not created → impossible if transaction is correct

### Concurrency

* User double-clicks Create Room.
* Two rooms generate same join code.
* Request retry after timeout may create duplicate rooms.

### API Contract

POST **/rooms**


    

    **Request**
    {
          "name": "Sprint Planning"
    }
	 
    **Response**
    {
      "roomId": "uuid",
      "joinCode": "ABCD12",
      "status": "Active",
      "currentUserRole": "Owner"
    }