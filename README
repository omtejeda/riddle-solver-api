# RiddleSolver

## Description
RiddleSolver is a .NET 8 REST API designed to tackle the **Water Jug Problem**. This project is built with extensibility in mind, making it easy to implement solutions for other riddles in the future.

The architecture consists of three layers, which helps to organize the codebase and enhance maintainability:
- **Api**: Manages HTTP requests and responses through controllers.
- **Core**: Contains the logic that solves the riddles.
- **Data**: Implements caching to improve performance and efficiency.

## Algorithmic Approach

To solve the **Water Jug Problem**, we use the **Breadth-First Search** (BFS) algorithm. The process begins with both jugs empty and explores possible actions-such as filling, emptying, and pouring—level by level. The goal is to find a state where one of the jugs contains the desired amount of water.

The algorithm tracks the steps taken, providing a clear record of actions and the state of each jug throughout the solution process.


## Endpoint
The REST API exposes the following endpoint:

### POST /api/v1/riddles/waterjug
- **URI**: `/api/v1/riddles/waterjug`
- **HTTP Method**: `POST`
- **Content Type**: `application/json`

### Sample Request
```json
{
  "capacityX": 3,
  "capacityY": 5,
  "amountWanted": 2
}

```

- __capacityX__: Capacity of the first jug.
- __capacityY__: Capacity of the second jug.
- __amountWanted__: Desired amount to measure.


### Responses
The API can return the following responses:

- __200 OK__: Success
```json
{
  "success": true,
  "status": "Success",
  "message": "SOLVED",
  "data": {
    "solution": [
      {
        "step": 1,
        "bucketX": 0,
        "bucketY": 5,
        "action": "Fill bucket y"
      },
      {
        "step": 2,
        "bucketX": 3,
        "bucketY": 2,
        "action": "Transfer from bucket y to bucket x. SOLVED"
      }
    ]
  }
}

```
- __400 Bad Request__: Validation Error
```json
{
  "success": false,
  "status": "ValidationError",
  "message": "Capacity X cannot be less than or equal to zero",
  "data": null
}
```

- __422 Unprocessable__: No solution
```json
{
  "success": false,
  "status": "Unprocessable",
  "message": "No solution was found",
  "data": null
}
```

### Description
- __success__: Indicates whether the operation was successful.
- __status__: Status of the request.
- __message__: Descriptive message about the result.
- __data__: Contains the solution to the riddle, represented as a list of steps.


## Installation
To run the RiddleSolver project, ensure you have the .NET 8 SDK installed on your machine.

1. Clone the repository:
```bash
git clone https://github.com/omtejeda/riddle-solver-api.git
```


2. Navigate to the project directory:
```bash
cd riddle-solver-api
```

3. Run the project
```bash
dotnet run --project src/Api
```


## License

[MIT](https://choosealicense.com/licenses/mit/)